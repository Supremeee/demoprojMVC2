using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoprojMVC.IBLL;

namespace demoprojMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private IT_UsersService usersService;

        public HomeController(IT_UsersService usersService)
        {
            this.usersService = usersService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}