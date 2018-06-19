using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SpringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();

            IUserInfoDal UserInfoDal = ctx.GetObject("UserInfoDal") as IUserInfoDal;
            UserInfoDal.Show();
            Console.ReadKey();
        }
    }
}
