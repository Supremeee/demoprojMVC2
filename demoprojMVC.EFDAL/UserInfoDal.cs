using System.Linq;
using demoprojMVC.Model;

namespace demoprojMVC.EFDAL
{
    public partial class UserInfoDal
    {
        public override bool Delete(string id)
        {
            bool result = false;
            var userInfo = GetEntities(u => u.ID == id).FirstOrDefault();
            if (userInfo != null)
            {
                Db.Entry(userInfo).Collection(u => u.RoleInfo).Load();
                Db.Entry(userInfo).Collection(u => u.R_UserInfo_ActionInfo).Load();
                Db.Set<UserInfo>().Remove(userInfo);
                result = true;
            }

            return result;
        }
    }
}