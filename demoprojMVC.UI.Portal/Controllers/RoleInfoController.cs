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
    public class RoleInfoController : BaseController
    {
        private IRoleInfoService roleInfoService;

        private int PageSize = 12;
        public RoleInfoController(IRoleInfoService serviceParam)
        {
            roleInfoService = serviceParam;
        }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            RoleInfo model = new RoleInfo();
            return View("Edit", model);
        }
        /// <summary>
        /// 新增一个权限信息 HttpGet
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string Id, bool isEdit = false)
        {
            RoleInfo model = roleInfoService.GetEntities(u => u.ID == Id).FirstOrDefault();
            if (model == null)
                RedirectToAction("Index");
            ViewBag.isEdit = isEdit;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RoleInfo roleInfo)
        {


            if (string.IsNullOrEmpty(roleInfo.ID))
            {
                roleInfo.ID = TableIDCodingRule.newID("roleinfo", "");
                roleInfo.ModfiedOn = DateTime.Now;
                roleInfo.SubTime = DateTime.Now;
                roleInfo.DelFlag = (short)DelFlagEnum.Normal;
                if (!ModelState.IsValid)
                    return View();
                roleInfoService.Add(roleInfo);
            }
            else
            {
                if (!ModelState.IsValid)
                    return View();
                roleInfoService.Update(roleInfo);
            }
            return View("Index");
        }
        public PartialViewResult GetRoleInfoData(int page = 1, string type = "", string searchContext = "")
        {
            int total;
            IEnumerable<RoleInfo> result = null;
            if (type != "" && searchContext != "")
            {
                result = Search(type, searchContext);
                result =
                    result.OrderBy(p => p.RoleName)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize);
                total = result.Count();
            }
            else
            {
                result = roleInfoService.GetPageEntites(PageSize, page, out total,
                u => u.DelFlag == (short)DelFlagEnum.Normal, u => u.RoleName, true);
            }
            
            RoleInfoViewModel model = new RoleInfoViewModel
            {
                RoleInfos = result,
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = total }
            };
            return PartialView(model);
        }
        private IEnumerable<RoleInfo> Search(string type, string searchContext)
        {
            IEnumerable<RoleInfo> result = null;
            switch (type.ToLower())
            {
                case "rolename":
                    result = roleInfoService.GetEntities(u => u.RoleName.Contains(searchContext));
                    break;
                case "remark":
                    result = roleInfoService.GetEntities(u => u.Remark.Contains(searchContext));
                    break;
                default:
                    break;
            }
            return result;
        }

        public ActionResult Delete(string roleInfoId)
        {
            if (string.IsNullOrEmpty(roleInfoId))
            {
                TempData["Message"] = "操作失败";
                return GetRoleInfoData();
            }
            roleInfoService.Delete(roleInfoId);
            TempData["Message"] = "操作成功";
            return RedirectToAction("GetRoleInfoData");
        }
       
    }
}