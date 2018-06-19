using System.Collections.Generic;
using System.Web.Mvc;
using demoprojMVC.Model;

namespace demoprojMVC.UI.Portal.Models
{
    public class StudnetEditViewModel
    {
        public td_students Student { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
        public IEnumerable<SelectListItem> Grades { get; set; }
        public IEnumerable<SelectListItem> Depts { get; set; }
        public IEnumerable<SelectListItem> Majors { get; set; }
        public IEnumerable<SelectListItem> Banjis { get; set; }
        public IEnumerable<SelectListItem> Nation { get; set; }
        public IEnumerable<SelectListItem> Politicstatus { get; set; }
        public IEnumerable<SelectListItem> Proviences { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Districts { get; set; }



    }
}