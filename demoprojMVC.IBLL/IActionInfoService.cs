using System.Collections.Generic;
using demoprojMVC.Model;

namespace demoprojMVC.IBLL
{
    public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
        bool SetRole(string actionId, List<string> roleIds);
    }
}