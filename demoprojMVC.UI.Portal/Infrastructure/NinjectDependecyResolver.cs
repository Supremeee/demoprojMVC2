using System;
using System.Collections.Generic;
using System.Web.Mvc;
using demoprojMVC.BLL;
using demoprojMVC.Common.Cache;
using demoprojMVC.IBLL;
using Ninject;

namespace demoprojMVC.UI.Portal.Infrastructure
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
            kernel.Bind<ICacheWriter>().To<MemcacheWriter>();
            kernel.Bind<IActionInfoService>().To<ActionInfoService>();
            kernel.Bind<IRoleInfoService>().To<RoleInfoService>();
            kernel.Bind(typeof(IUserInfoService) ).To(typeof(UserInfoService));
            kernel.Bind(typeof(IR_UserInfo_ActionInfoService)).To(typeof(R_UserInfo_ActionInfoService));
        }
    }
}