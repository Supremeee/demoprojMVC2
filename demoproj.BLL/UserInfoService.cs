using System.Collections.Generic;
using System.Linq;
using demoprojMVC.Model;

namespace demoprojMVC.BLL
{
    public partial class UserInfoService
    {
        public bool SetRole(string userId, List<string> roleIds)
        {
            UserInfo userInfo = DbSession.UserInfoDal.GetEntities(u => u.ID == userId).FirstOrDefault();
            if (userInfo == null)
                return false;
            userInfo.RoleInfo.Clear();
            IEnumerable<RoleInfo> roleInfos = DbSession.RoleInfoDal.GetEntities(u => roleIds.Contains(u.ID));
            foreach (var roleInfo in roleInfos)
            {
                userInfo.RoleInfo.Add(roleInfo);
            }
            DbSession.SaveChanges();
            return true;
        }
    }
}