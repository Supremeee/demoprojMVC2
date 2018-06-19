using System;
using demoprojMVC.BLL;
using demoprojMVC.IBLL;
using Ninject.Modules;

namespace NinjectDmo
{
    public class DemoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Itd_studentsService>().To<td_studentsService>();
        }
    }
}