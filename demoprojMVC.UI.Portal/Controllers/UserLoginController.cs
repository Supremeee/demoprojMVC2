using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using demoprojMVC.BLL;
using demoprojMVC.Common.Cache;
using demoprojMVC.IBLL;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Controllers
{
    
    public class UserLoginController : Controller
    {

        private readonly IUserInfoService usersService;
        
        // GET: UserLogin
        public UserLoginController(IUserInfoService serviceParam)
        {
            usersService = serviceParam;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            //password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            UserInfo result = usersService.GetEntities(u => u.UName == username && u.Pwd == password).FirstOrDefault();
            
            if (result != null)
            {
                string userLoginId = Guid.NewGuid().ToString();

                CacheHelper.AddCache(userLoginId, result,DateTime.Now.AddMinutes(20));
                Response.Cookies["userLoginId"].Value = userLoginId;
                Session["UserInfo"] = result;
                return RedirectToAction("Index", "Home");

            }
                

            return View();
        }

        public ActionResult LoginOut()
        {
            var httpCookie = Request.Cookies["userLoginId"];
            if (httpCookie != null)
            {
                var cookie = Request.Cookies["Menu"];
                if (cookie != null)
                {
                    string menuId = cookie.Value;
                    CacheHelper.SetCache(menuId, null, DateTime.Now);
                }


                string userLoginId = httpCookie.Value;
                Session["UserInfo"] = null;
                CacheHelper.SetCache(userLoginId,null,DateTime.Now);
                Response.Cookies.Clear();
            }
            return RedirectToAction("Index");
        }
    }
}