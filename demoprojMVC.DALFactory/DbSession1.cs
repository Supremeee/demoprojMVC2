 
using demoprojMVC.EFDAL;
using demoprojMVC.IDAL;

namespace demoprojMVC.DALFactory
{
    public partial class DbSession :IDbSession
    {
   
		
	public IactDal actDal
    {
        get { return StaticDalFactory.GetactDal(); }
    }
		
	public IActionInfoDal ActionInfoDal
    {
        get { return StaticDalFactory.GetActionInfoDal(); }
    }
		
	public Iapplication_listDal application_listDal
    {
        get { return StaticDalFactory.Getapplication_listDal(); }
    }
		
	public IDepartmentDal DepartmentDal
    {
        get { return StaticDalFactory.GetDepartmentDal(); }
    }
		
	public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
    {
        get { return StaticDalFactory.GetR_UserInfo_ActionInfoDal(); }
    }
		
	public IRoleInfoDal RoleInfoDal
    {
        get { return StaticDalFactory.GetRoleInfoDal(); }
    }
		
	public IT_AppDal T_AppDal
    {
        get { return StaticDalFactory.GetT_AppDal(); }
    }
		
	public IT_RolesDal T_RolesDal
    {
        get { return StaticDalFactory.GetT_RolesDal(); }
    }
		
	public IT_UsersDal T_UsersDal
    {
        get { return StaticDalFactory.GetT_UsersDal(); }
    }
		
	public Itd_studentsDal td_studentsDal
    {
        get { return StaticDalFactory.Gettd_studentsDal(); }
    }
		
	public IUserInfoDal UserInfoDal
    {
        get { return StaticDalFactory.GetUserInfoDal(); }
    }
	}
}