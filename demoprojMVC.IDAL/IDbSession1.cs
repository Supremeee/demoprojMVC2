 
namespace demoprojMVC.IDAL
{
    public partial interface IDbSession
    {
   
	 
		IactDal actDal { get;}
	 
		IActionInfoDal ActionInfoDal { get;}
	 
		Iapplication_listDal application_listDal { get;}
	 
		IDepartmentDal DepartmentDal { get;}
	 
		IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get;}
	 
		IRoleInfoDal RoleInfoDal { get;}
	 
		IT_AppDal T_AppDal { get;}
	 
		IT_RolesDal T_RolesDal { get;}
	 
		IT_UsersDal T_UsersDal { get;}
	 
		Itd_studentsDal td_studentsDal { get;}
	 
		IUserInfoDal UserInfoDal { get;}
	}

}