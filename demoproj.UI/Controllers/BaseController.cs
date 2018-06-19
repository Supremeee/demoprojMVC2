using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoprojMVC.Common.Cache;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Controllers
{
    public class BaseController : Controller
    {
        public bool isCheckUserLogin = true;
        public T_Users loginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var items = filterContext.RouteData.Values;

            if (isCheckUserLogin)
            {
                if (Request.Cookies["userLoginId"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");   
                }
                else
                {
                    string userGuid = Request.Cookies["userLoginId"].Value;
                    T_Users userInfo = CacheHelper.GetCache(userGuid) as T_Users;
                    if (userInfo == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    }
                    CacheHelper.SetCache(userGuid,userInfo,DateTime.Now.AddMinutes(20));
                }
                
                
                //if (filterContext.HttpContext.Session["loginUser"] == null)
                //    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                //else
                //    loginUser = filterContext.HttpContext.Session["loginUser"] as T_Users;

            }
        }
    }
}