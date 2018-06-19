using System.Collections.Generic;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Models
{
    public class UserInfoViewModel
    {
        public IEnumerable<UserInfo> UserInfos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}