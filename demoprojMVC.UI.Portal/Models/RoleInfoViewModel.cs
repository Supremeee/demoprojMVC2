using System.Collections.Generic;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Models
{
    public class RoleInfoViewModel
    {
        public IEnumerable<RoleInfo> RoleInfos { get; set; }

        public PagingInfo PagingInfo { get; set; } 
    }
}