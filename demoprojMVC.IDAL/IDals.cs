 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoprojMVC.Model;

namespace demoprojMVC.IDAL
{
   
		
	public partial interface IactDal : IBaseDal<act>
    {
	}   
		
	public partial interface IActionInfoDal : IBaseDal<ActionInfo>
    {
	}   
		
	public partial interface Iapplication_listDal : IBaseDal<application_list>
    {
	}   
		
	public partial interface IDepartmentDal : IBaseDal<Department>
    {
	}   
		
	public partial interface IR_UserInfo_ActionInfoDal : IBaseDal<R_UserInfo_ActionInfo>
    {
	}   
		
	public partial interface IRoleInfoDal : IBaseDal<RoleInfo>
    {
	}   
		
	public partial interface IT_AppDal : IBaseDal<T_App>
    {
	}   
		
	public partial interface IT_RolesDal : IBaseDal<T_Roles>
    {
	}   
		
	public partial interface IT_UsersDal : IBaseDal<T_Users>
    {
	}   
		
	public partial interface Itd_studentsDal : IBaseDal<td_students>
    {
	}   
		
	public partial interface IUserInfoDal : IBaseDal<UserInfo>
    {
	}   


}