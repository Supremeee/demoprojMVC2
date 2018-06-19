using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoprojMVC.DALFactory
{
    public partial class StaticDalFactory
    {
        public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];

    }
}
