
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoprojMVC.DALFactory;
using demoprojMVC.EFDAL;
using demoprojMVC.IBLL;
using demoprojMVC.IDAL;
using demoprojMVC.Model;


namespace demoprojMVC.BLL
{
	
	public partial class actService:BaseService<act>,IactService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.actDal;
        } 
	}
	
	public partial class ActionInfoService:BaseService<ActionInfo>,IActionInfoService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.ActionInfoDal;
        } 
	}
	
	public partial class application_listService:BaseService<application_list>,Iapplication_listService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.application_listDal;
        } 
	}
	
	public partial class DepartmentService:BaseService<Department>,IDepartmentService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.DepartmentDal;
        } 
	}
	
	public partial class R_UserInfo_ActionInfoService:BaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.R_UserInfo_ActionInfoDal;
        } 
	}
	
	public partial class RoleInfoService:BaseService<RoleInfo>,IRoleInfoService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.RoleInfoDal;
        } 
	}
	
	public partial class T_AppService:BaseService<T_App>,IT_AppService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.T_AppDal;
        } 
	}
	
	public partial class T_RolesService:BaseService<T_Roles>,IT_RolesService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.T_RolesDal;
        } 
	}
	
	public partial class T_UsersService:BaseService<T_Users>,IT_UsersService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.T_UsersDal;
        } 
	}
	
	public partial class td_studentsService:BaseService<td_students>,Itd_studentsService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.td_studentsDal;
        } 
	}
	
	public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService //crud
    {
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        } 
	}
}