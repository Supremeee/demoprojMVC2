using System.Collections.Generic;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Models
{
    public class ActionInfoViewModel
    {
        public IEnumerable<ActionInfo> ActionInfos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}