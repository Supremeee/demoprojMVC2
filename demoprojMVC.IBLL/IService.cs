 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoprojMVC.Model;

namespace demoprojMVC.IBLL
{
	
    public partial interface IactService:IBaseService<act>
    {
    }
	
    public partial interface IActionInfoService:IBaseService<ActionInfo>
    {
    }
	
    public partial interface Iapplication_listService:IBaseService<application_list>
    {
    }
	
    public partial interface IDepartmentService:IBaseService<Department>
    {
    }
	
    public partial interface IR_UserInfo_ActionInfoService:IBaseService<R_UserInfo_ActionInfo>
    {
    }
	
    public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {
    }
	
    public partial interface IT_AppService:IBaseService<T_App>
    {
    }
	
    public partial interface IT_RolesService:IBaseService<T_Roles>
    {
    }
	
    public partial interface IT_UsersService:IBaseService<T_Users>
    {
    }
	
    public partial interface Itd_studentsService:IBaseService<td_students>
    {
    }
	
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
    }
}