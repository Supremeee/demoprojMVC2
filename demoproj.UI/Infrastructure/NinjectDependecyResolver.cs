using System;
using System.Collections.Generic;
using System.Web.Mvc;
using demoprojMVC.BLL;
using demoprojMVC.IBLL;
using Ninject;

namespace demoprojMVC.UI.Infrastructure
{
    public class NinjectDependecyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependecyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
            
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<Itd_studentsService>().To<td_studentsService>();
            kernel.Bind<IT_UsersService>().To<T_UsersService>();
        }
    }
}