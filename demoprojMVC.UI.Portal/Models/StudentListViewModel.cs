using System.Collections.Generic;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Models
{
    public class StudentListViewModel
    {
        public IEnumerable<td_students> Students { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}