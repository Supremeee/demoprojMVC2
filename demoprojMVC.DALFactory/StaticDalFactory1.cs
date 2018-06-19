 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using demoprojMVC.EFDAL;
using demoprojMVC.IDAL;


namespace demoprojMVC.DALFactory
{
    /// <summary>
    /// 由简单工厂转变成了抽象工厂。
    /// 抽象工厂  VS  简单工厂
    /// 
    /// </summary>
    public partial class StaticDalFactory
    {
   
	
		public static IactDal GetactDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".actDal")
				as IactDal;
		}
	
		public static IActionInfoDal GetActionInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".ActionInfoDal")
				as IActionInfoDal;
		}
	
		public static Iapplication_listDal Getapplication_listDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".application_listDal")
				as Iapplication_listDal;
		}
	
		public static IDepartmentDal GetDepartmentDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".DepartmentDal")
				as IDepartmentDal;
		}
	
		public static IR_UserInfo_ActionInfoDal GetR_UserInfo_ActionInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".R_UserInfo_ActionInfoDal")
				as IR_UserInfo_ActionInfoDal;
		}
	
		public static IRoleInfoDal GetRoleInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".RoleInfoDal")
				as IRoleInfoDal;
		}
	
		public static IT_AppDal GetT_AppDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".T_AppDal")
				as IT_AppDal;
		}
	
		public static IT_RolesDal GetT_RolesDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".T_RolesDal")
				as IT_RolesDal;
		}
	
		public static IT_UsersDal GetT_UsersDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".T_UsersDal")
				as IT_UsersDal;
		}
	
		public static Itd_studentsDal Gettd_studentsDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".td_studentsDal")
				as Itd_studentsDal;
		}
	
		public static IUserInfoDal GetUserInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal")
				as IUserInfoDal;
		}
	}
}