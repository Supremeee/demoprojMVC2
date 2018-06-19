using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using demoprojMVC.BLL;
using demoprojMVC.Common.Cache;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using Ninject;

namespace demoprojMVC.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        public bool isCheckUserLogin = true;
        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //var items = filterContext.RouteData.Values;
            
            if (isCheckUserLogin)
            {
                #region 验证用户登录
                if (Request.Cookies["userLoginId"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                else
                {
                    string userGuid = Request.Cookies["userLoginId"].Value;
                    LoginUser = CacheHelper.GetCache(userGuid) as UserInfo;
                    if (LoginUser == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                        return;
                    }
                    CacheHelper.SetCache(userGuid, LoginUser, DateTime.Now.AddMinutes(20));
                }
                #endregion
                if(LoginUser.UName =="admin")
                    return;
                #region 校验权限

                string url = Request.Url.AbsolutePath.ToLower();
                string httpMethod = Request.HttpMethod.ToLower();

                //通过容器创建一个对象;

                IActionInfoService actionInfoService = new ActionInfoService();
                IR_UserInfo_ActionInfoService rUseActionService = new R_UserInfo_ActionInfoService();
                IUserInfoService userInfoService = new UserInfoService();

                ActionInfo actionInfo =
                    actionInfoService.GetEntities(a => url.Contains(a.Url.ToLower()) && a.HttpMethd.ToLower() == httpMethod)
                        .FirstOrDefault();
                if (actionInfo == null)
                {
                    Response.Redirect("/Error.html");
                    return;
                }
                //一号线
               IEnumerable<R_UserInfo_ActionInfo> rUserActions = rUseActionService.GetEntities(u => u.UserInfoID == LoginUser.ID);
                var item = (from a in rUserActions
                    where a.ActionInfoID == actionInfo.ID
                    select a).FirstOrDefault();
                if (item != null)
                {
                    if (item.HasPermission)
                    {
                        return;
                    }
                    else
                    {
                        Response.Redirect("/Error.html");
                        return;
                    }
                }
                //2号线
                var user = userInfoService.GetEntities(u => u.ID == LoginUser.ID).FirstOrDefault();
                var allRoles = from r in user.RoleInfo
                    select r;
                var actions = from r in allRoles
                    from a in r.ActionInfo
                    select a;
                var temp = (from a in actions
                            where a.ID == actionInfo.ID
                            select  a).Count();
                if (temp <= 0)
                {
                    Response.Redirect("/Error.html");
                }
                #endregion
            }
        }
    }
}