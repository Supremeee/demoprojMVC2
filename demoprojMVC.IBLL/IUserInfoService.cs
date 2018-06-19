using System.Collections.Generic;

namespace demoprojMVC.IBLL
{
    public partial interface IUserInfoService
    {
        bool SetRole(string userId, List<string> roleIds);
    }
}