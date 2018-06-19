 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using demoprojMVC.IDAL;
using demoprojMVC.Model;

namespace demoprojMVC.EFDAL
{
   
		
	public partial class actDal:BaseDal<act>,IactDal
    {
	}
		
	public partial class ActionInfoDal:BaseDal<ActionInfo>,IActionInfoDal
    {
	}
		
	public partial class application_listDal:BaseDal<application_list>,Iapplication_listDal
    {
	}
		
	public partial class DepartmentDal:BaseDal<Department>,IDepartmentDal
    {
	}
		
	public partial class R_UserInfo_ActionInfoDal:BaseDal<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDal
    {
	}
		
	public partial class RoleInfoDal:BaseDal<RoleInfo>,IRoleInfoDal
    {
	}
		
	public partial class T_AppDal:BaseDal<T_App>,IT_AppDal
    {
	}
		
	public partial class T_RolesDal:BaseDal<T_Roles>,IT_RolesDal
    {
	}
		
	public partial class T_UsersDal:BaseDal<T_Users>,IT_UsersDal
    {
	}
		
	public partial class td_studentsDal:BaseDal<td_students>,Itd_studentsDal
    {
	}
		
	public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
	}


}