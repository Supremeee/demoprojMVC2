using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoprojMVC.BLL;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using Ninject;

namespace NinjectDmo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new DemoModule());

            NinjectDemo demo = kernel.Get<NinjectDemo>();
            demo.Print();
            Console.ReadKey();
        }
    }
}
