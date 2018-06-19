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
    public class ActionInfoController : BaseController
    {
        private IActionInfoService actionInfoService;
        private IRoleInfoService roleInfoService;
        private int PageSize = 12;
        public ActionInfoController(IActionInfoService serviceParam,IRoleInfoService roleInfoServiceParam)
        {
            actionInfoService = serviceParam;
            roleInfoService = roleInfoServiceParam;
        }
        // GET: ActionInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ActionInfo model = new ActionInfo();
            return View("Edit", model);
        }
        /// <summary>
        /// 新增一个权限信息 HttpGet
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string Id, bool isEdit = false)
        {
            ActionInfo model = actionInfoService.GetEntities(u => u.ID == Id).FirstOrDefault();
            if (model == null)
                RedirectToAction("Index");
            ViewBag.isEdit = isEdit;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ActionInfo actionInfo)
        {

            
            if (string.IsNullOrEmpty(actionInfo.ID))
            {
                actionInfo.ID = TableIDCodingRule.newID("actioninfo", "");
                actionInfo.ModfiedOn = DateTime.Now;
                actionInfo.SubTime = DateTime.Now;
                actionInfo.DelFlag = (short)DelFlagEnum.Normal;
                if (!ModelState.IsValid)
                    return View();
                actionInfoService.Add(actionInfo);
            }
            else
            {
                if (!ModelState.IsValid)
                    return View();
                actionInfoService.Update(actionInfo);
            }
            return View("Index");
        }

        public PartialViewResult GetActionInfoData(int page = 1, string type = "", string searchContext = "")
        {
            int total;
            IEnumerable<ActionInfo> result = null;
            if (type != "" && searchContext != "")
            {
                result = Search(type, searchContext);
                result =
                    result.OrderBy(p => p.ActionName)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize);
                total = result.Count();
            }
            else
            {
                result = actionInfoService.GetPageEntites(PageSize, page, out total,
               u => u.DelFlag == (short)DelFlagEnum.Normal, u => u.ActionName, true);
            }
            ActionInfoViewModel model = new ActionInfoViewModel
            {
                ActionInfos = result,
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = total }
            };
            return PartialView(model);
        }

        private IEnumerable<ActionInfo> Search(string type, string searchContext)
        {
            IEnumerable<ActionInfo> result = null;
            switch (type.ToLower())
            {
                case "actionname":
                    result = actionInfoService.GetEntities(u => u.ActionName.Contains(searchContext));
                    break;
                case "url":
                    result = actionInfoService.GetEntities(u => u.Url.Contains(searchContext));
                    break;
                default:
                    break;
            }
            return result;
        }

        public ActionResult Delete(string actionInfoId)
        {
            if (string.IsNullOrEmpty(actionInfoId))
            {
                TempData["Message"] = "操作失败";
                return GetActionInfoData();
            }
            actionInfoService.Delete(actionInfoId);
            TempData["Message"] = "操作成功";
            return RedirectToAction("GetActionInfoData");
        }
        public ActionResult SetRoleUI(string id)
        {
            ActionInfo model = actionInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
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
                actionInfoService.SetRole(id, setRoleIdList);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
            return Content("ok");
        }
    }
}