using System.Web.Mvc;
using System.Web.Routing;
using demoprojMVC.UI.Infrastructure;
using Ninject;

namespace demoprojMVC.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //注册Ninject
            DependencyResolver.SetResolver(new NinjectDependecyResolver(new StandardKernel()));
        }
    }
}
