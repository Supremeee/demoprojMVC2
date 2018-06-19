using System.Linq;
using demoprojMVC.Model;

namespace demoprojMVC.EFDAL
{
    public partial class RoleInfoDal
    {
        public override bool Delete(string id)
        {
            bool result = false;
            var roleInfo = GetEntities(u => u.ID == id).FirstOrDefault();
            if (roleInfo != null)
            {
                Db.Entry(roleInfo).Collection(u => u.ActionInfo).Load();
                Db.Entry(roleInfo).Collection(u => u.UserInfo).Load();
                Db.Set<RoleInfo>().Remove(roleInfo);
                result = true;
            }
            return result;
        }
    }
}