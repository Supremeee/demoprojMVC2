using System.Collections.Generic;
using System.Linq;
using demoprojMVC.Model;
using demoprojMVC.Model.Enum;

namespace demoprojMVC.BLL
{
    public partial class ActionInfoService
    {
        public bool SetRole(string actionId, List<string> roleIds)
        {
            ActionInfo actionInfo = DbSession.ActionInfoDal.GetEntities(u => u.ID == actionId).FirstOrDefault();
            if (actionInfo == null)
                return false;
            actionInfo.RoleInfo.Clear();
            IEnumerable<RoleInfo> roleInfos = DbSession.RoleInfoDal.GetEntities(u => roleIds.Contains(u.ID));
            foreach (var roleInfo in roleInfos)
            {
                actionInfo.RoleInfo.Add(roleInfo);
            }
            DbSession.SaveChanges();
            return true;
        }
    }
}