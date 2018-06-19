using System.Linq;
using demoprojMVC.Model;

namespace demoprojMVC.EFDAL
{
    public partial class ActionInfoDal
    {
        public override bool Delete(string id)
        {
            bool result = false;
            var actionInfo = GetEntities(u => u.ID == id).FirstOrDefault();
            if (actionInfo != null)
            {
                Db.Entry(actionInfo).Collection(u=>u.RoleInfo).Load();
                Db.Entry(actionInfo).Collection(u => u.R_UserInfo_ActionInfo).Load();
                Db.Set<ActionInfo>().Remove(actionInfo);
                result = true;
            }

            return result;
        }
    }
}