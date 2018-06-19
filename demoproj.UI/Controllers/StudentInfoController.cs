using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using demoprojMVC.BLL;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using demoprojMVC.UI.Models;


namespace demoprojMVC.UI.Controllers
{
    public class StudentInfoController : BaseController
    {
        // GET: SutdentInfo

        private Itd_studentsService StudentService = new td_studentsService();

       
        //public StudentInfoController(Itd_studentsService serviceParam)
        //{
        //    StudentService = serviceParam;
        //}
    
        public int PageSize = 12;
        public ViewResult List(int page = 1)
        {

            return View();
        }
        public PartialViewResult GetStudentData(int page = 1)
        {
            int total = 0;
            IEnumerable<td_students> result =  StudentService.GetPageEntites<string>(PageSize, page, out total, u => true, t => t.school_code, true);
            StudentListViewModel model = new StudentListViewModel
            {
                Students = result,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalItems = total
                }
            };
            return PartialView(model);
        }
    }
}