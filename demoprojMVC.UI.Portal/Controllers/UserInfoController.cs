using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoprojMVC.Common;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using demoprojMVC.Model.Enum;
using demoprojMVC.UI.Portal.Models;

namespace demoprojMVC.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        private IUserInfoService userInfoService;
        private IRoleInfoService roleInfoService;
        private IR_UserInfo_ActionInfoService rUserActionService;
        private IActionInfoService actionService;
        private int PageSize = 12;
        public UserInfoController(IUserInfoService serviceParam,IRoleInfoService roleServiceParam, IR_UserInfo_ActionInfoService userActionServiceParam, IActionInfoService actionServiceParam)
        {
            userInfoService = serviceParam;
            roleInfoService = roleServiceParam;
            rUserActionService = userActionServiceParam;
            actionService = actionServiceParam;
        }
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            UserInfo model = new UserInfo();
            return View("Edit", model);
        }
        /// <summary>
        /// 新增一个权限信息 HttpGet
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string Id, bool isEdit = false)
        {
            UserInfo model = userInfoService.GetEntities(u => u.ID == Id).FirstOrDefault();
            if (model == null)
                RedirectToAction("Index");
            ViewBag.isEdit = isEdit;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {


            if (string.IsNullOrEmpty(userInfo.ID))
            {
                userInfo.ID = TableIDCodingRule.newID("userinfo", "");
                userInfo.ModfiedOn = DateTime.Now;
                userInfo.SubTime = DateTime.Now;
                userInfo.DelFlag = (short)DelFlagEnum.Normal;
                if (!ModelState.IsValid)
                    return View();
                userInfoService.Add(userInfo);
            }
            else
            {
                if (!ModelState.IsValid)
                    return View();
                userInfoService.Update(userInfo);
            }
            return View("Index");
        }
        //获取用户列表信息
        public PartialViewResult GetUserInfoData(int page = 1,string type="", string searchContext="")
        {
            int total;
            IEnumerable<UserInfo> result = null;
            if (type != "" && searchContext != "")
            {
                result = Search(type, searchContext);
                result = result.OrderBy(u => u.UName).ThenBy(u => u.ShowName).Skip((page-1)*PageSize).Take(PageSize);
                total = result.Count();
            }
            else
            {
                result = userInfoService.GetPageEntites(PageSize, page, out total,
                u => u.DelFlag == (short)DelFlagEnum.Normal, u => u.UName, true);
            }
            
            UserInfoViewModel model = new UserInfoViewModel
            {
                UserInfos = result,
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = total }
            };
            return PartialView(model);
        }
        private IEnumerable<UserInfo> Search(string type, string searchContext)
        {
            IEnumerable<UserInfo> result = null;
            switch (type.ToLower())
            {
                case "uname":
                    result = userInfoService.GetEntities(u => u.UName.Contains(searchContext));
                    break;
                case "showname":
                    result = userInfoService.GetEntities(u => u.ShowName.Contains(searchContext));
                    break;
                default:
                    break;
            }
            return result;
        }

        public ActionResult Delete(string userInfoId)
        {
            if (string.IsNullOrEmpty(userInfoId))
            {
                TempData["Message"] = "操作失败";
                return GetUserInfoData();
            }
            userInfoService.Delete(userInfoId);
            TempData["Message"] = "操作成功";
            return RedirectToAction("GetUserInfoData");
        }

        //获取设置用户权限的界面
        public ActionResult SetRoleUI(string id)
        {
            UserInfo model = userInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
            if (model == null)
            {
                TempData["ErrMsg"] = "未查找到当前用户";
                return Content("error");
            }
            ViewBag.AllRoles = roleInfoService.GetEntities(u => true).ToList();
            ViewBag.ExistRoles = (from r in model.RoleInfo
                select r.ID).ToList();
            return PartialView(model);

        }
        //设置用户权限
        public ActionResult ProcessSetRole(string id)
        {
            try
            {
                List<string> setRoleIdList = new List<string>();
                foreach (var key in Request.Form.AllKeys)
                {
                    if (key.StartsWith("ckb_"))
                    {
                        string roleId = key.Replace("ckb_", "");
                        setRoleIdList.Add(roleId);
                    }
                }
                userInfoService.SetRole(id, setRoleIdList);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
            return Content("ok");
        }
        
        /// <summary>
        /// 设置用户特殊权限
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns></returns>
        public ActionResult SetUserAction(string id)
        {
            Dictionary<string,bool> existActions = new Dictionary<string, bool>();
            UserInfo model = userInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
            ViewBag.AllActions = actionService.GetEntities(u => true).ToList();
            existActions = rUserActionService.GetEntities(u => u.UserInfoID == id).ToDictionary(u=>u.ActionInfoID,u=>u.HasPermission);
            ViewBag.ExistActions = existActions;
            return View(model);
        }
        [HttpPost]
        public ActionResult SetUserAction(string userId, string actionId, int value)
        {
            try
            {
                R_UserInfo_ActionInfo userAction =
                rUserActionService.GetEntities(r => r.ActionInfoID == actionId && r.UserInfoID == userId)
                    .FirstOrDefault();
                if (userAction != null)
                {
                    userAction.HasPermission = value == 1;
                    rUserActionService.Update(userAction);
                }
                else
                {
                    userAction = new R_UserInfo_ActionInfo();
                    userAction.ID = TableIDCodingRule.newID("useraction", "");
                    userAction.ActionInfoID = actionId;
                    userAction.UserInfoID = userId;
                    userAction.DelFlag = (short)DelFlagEnum.Normal;
                    rUserActionService.Add(userAction);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
            return Content("ok");
        }

        //删除用户权限
        [HttpPost]
        public ActionResult DeleteUserAction(string userId, string actionId)
        {
            var userAction = rUserActionService.GetEntities(r => r.ActionInfoID == actionId && r.UserInfoID == userId).FirstOrDefault();
            if (userAction != null)
            {
                rUserActionService.Delete(new List<string> {userAction.ID});
            }
            return Content("ok");
        }

    }
}