using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using demoprojMVC.UI.Portal.Infrastructure;
using Ninject;

namespace demoprojMVC.UI.Portal
{
    public class MvcApplication : HttpApplication//Spring.Web.Mvc.SpringMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new NinjectDependecyResolver(new StandardKernel()));
        }
    }
}
