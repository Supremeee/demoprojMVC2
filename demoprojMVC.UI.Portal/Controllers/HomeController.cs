using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using demoprojMVC.Common.Cache;
using demoprojMVC.IBLL;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserInfoService usersService;
        private readonly IActionInfoService actionService;
        private readonly ICacheWriter cacheWriter;

        public HomeController(IUserInfoService serviceParam, IActionInfoService actionServiceParam,
            ICacheWriter cacheWriterParam)
        {
            usersService = serviceParam;
            actionService = actionServiceParam;
            cacheWriter = cacheWriterParam;
        }

        // GET: Home
        public ActionResult Index()
        {
            usersService.GetEntities(u => true);
            return View();
        }

        public ActionResult Menu()
        {
            List<ActionInfo> actionList = null;
            if (Request.Cookies["Menu"] == null)
            {
                actionList = GetActionInfos();
                //向缓存写入菜单项
                string menuCookieId = Guid.NewGuid().ToString();
                Response.Cookies["Menu"].Value = menuCookieId;
                cacheWriter.AddCache(menuCookieId, actionList);

            }
            else
            {
                string menuCookieId = Request.Cookies["Menu"].Value;
                actionList = cacheWriter.GetCache(menuCookieId) as List<ActionInfo>;
                if (actionList == null)
                {
                    actionList = GetActionInfos();
                    //向缓存写入菜单项
                    menuCookieId = Guid.NewGuid().ToString();
                    Response.Cookies["Menu"].Value = menuCookieId;
                    cacheWriter.AddCache(menuCookieId, actionList);
                }
            }
            return PartialView(actionList);
        }

        public List<ActionInfo> GetActionInfos()
        {
            List<ActionInfo> actionList = new List<ActionInfo>();
            //拿到当前用户
            string userId = this.LoginUser.ID;
            var user = usersService.GetEntities(u => u.ID == userId).FirstOrDefault();
            //拿到当前用户所有权限【必须是菜单的权限】
            if (user != null)
            {
                IEnumerable<RoleInfo> allRole = user.RoleInfo;

                //拿到用户对应的所有角色的权限的id
                List<string> allRoleActionIds = (from r in allRole
                    from a in r.ActionInfo
                    //where a.IsMenu == true
                    select a.ID).ToList();
                //拿到用户直接拒绝的权限
                List<string> allDenyActionIds = (from r in user.R_UserInfo_ActionInfo
                    where r.HasPermission == false
                    select r.ActionInfoID).ToList();
                //角色权限-特殊拒绝权限
                List<string> allActionIds = allRoleActionIds.Where(u => !allDenyActionIds.Contains(u)).ToList();
                //特殊允许权限
                List<string> allPremissActionIds =
                    user.R_UserInfo_ActionInfo.Where(u => u.HasPermission == true).Select(u => u.ID).ToList();
                allActionIds.AddRange(allPremissActionIds.AsEnumerable());
                allActionIds = allActionIds.Distinct().ToList();
                actionList =
                    actionService.GetEntities(a => allActionIds.Contains(a.ID) && a.IsMenu)
                        .OrderBy(u => u.ActionName)
                        .ToList();
            }
            return actionList;
        }
    }
}