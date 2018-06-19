using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using demoprojMVC.BLL;
using demoprojMVC.Common.Cache;
using demoprojMVC.IBLL;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Controllers
{
    
    public class UserLoginController : Controller
    {
        private IT_UsersService usersService = new T_UsersService();
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                string userLoginId = Guid.NewGuid().ToString();

                CacheHelper.AddCache(userLoginId,new T_Users {user_name = "admin"},DateTime.Now.AddMinutes(20));
                Response.Cookies["userLoginId"].Value = userLoginId;
                return RedirectToAction("List", "StudentInfo");

            }
                

            return Content("登录失败");
        }
    }
}