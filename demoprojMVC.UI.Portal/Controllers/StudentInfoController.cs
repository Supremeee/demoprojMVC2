using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using demoprojMVC.BLL;
using demoprojMVC.Common;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using demoprojMVC.UI.Portal.Helpers;
using demoprojMVC.UI.Portal.Models;

namespace demoprojMVC.UI.Portal.Controllers
{
    public class StudentInfoController : BaseController
    {
        // GET: SutdentInfo

        private Itd_studentsService StudentService;


        public StudentInfoController(Itd_studentsService serviceParam)
        {
            StudentService = serviceParam;
        }

        public int PageSize = 12;
        public ViewResult List(int page = 1)
        {

            return View();
        }
        /// <summary>
        /// 新增一个学生信息 HttpGet
        /// </summary>
        /// <returns></returns>
        public ViewResult Create()
        {
            StudnetEditViewModel model = GetInitStudentEditModel();
            return View("Edit", model);
        }
        /// <summary>
        /// 新增一个学生信息 HttpGet
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string Id, bool isEdit = false)
        {
            StudnetEditViewModel model = GetSutdentEditModel(Id);
            if (model == null)
                RedirectToAction("List");
            ViewBag.isEdit = isEdit;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(td_students student, string province = "", string city = "", string district = "")
        {
            if (!ModelState.IsValid)
            {
                //获取所有错误的Key
                List<string> Keys = ModelState.Keys.ToList();
                //获取每一个key对应的ModelStateDictionary
                foreach (var key in Keys)
                {
                    var errors = ModelState[key].Errors.ToList();
                    //将错误描述输出到控制台
                    foreach (var error in errors)
                    {
                        TempData["Errmsg"] += error.ErrorMessage + "\r\n";
                    }
                }
                StudnetEditViewModel model = GetSutdentEditModel(student.id);
                model.Student = student;
                return View(model);
            }
            if (province != "" && city != "" && district != "")
                student.native_place = string.Format("{0}-{1}-{2}", province, city, district);
            if (string.IsNullOrEmpty(student.id))
            {
                student.id = TableIDCodingRule.newID("td_students", "");
                student.audit = false;
                student.@lock = false;
                StudentService.Add(student);
            }

            else
                StudentService.Update(student);
            TempData["Message"] = string.Format("学号{0} 姓名{1} 数据已保存", student.school_code, student.student_name);
            return RedirectToAction("List");
        }
        /// <summary>
        /// 查看学生基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(string id)
        {
            td_students student =
                StudentService.GetEntities(u => u.id == id).FirstOrDefault();
            if (student == null)
            {
                TempData["ErrMsg"] = "未查找到相应的信息";
                return RedirectToAction("List");
            }
            ViewBag.ShowEdit = true;
            if (student.@lock != null && student.audit != null && (student.audit.Value || student.@lock.Value))
                ViewBag.ShowEdit = false;

            student = TransferToStudent(student);
            return View(student);
        }
        /// <summary>
        /// 将数据库中的编码转换为汉字
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private td_students TransferToStudent(td_students student)
        {
            student.banji = XmlHelper.GetOneByXPath("SimpleData.xml",
                $"/DD/DItems[@DValue='banji']/DItem[@DValue='{student.banji}']", "Text");
            student.grade = XmlHelper.GetOneByXPath("SimpleData.xml",
                $"/DD/DItems[@DValue='grade']/DItem[@DValue='{student.grade}']", "Text");
            string dept = student.dept;
            student.dept = XmlHelper.GetOneByXPath("deptlist.xml",
                $"/Departments/Department[@Dept_code='{student.dept}']", "Dept_name");
            student.major = XmlHelper.GetOneByXPath("Major.xml",
                $"/Majors/DItems[@DValue='{dept}']/DItem[@DValue='{student.major}']", "Dept_name");
            student.gender = XmlHelper.GetOneByXPath("SimpleData.xml",
                $"/DD/DItems[@DValue='gender']/DItem[@DValue='{student.gender}']", "Text");
            if (student.nation != null)
            {
                student.nation = XmlHelper.GetOneByXPath("SimpleData.xml",
                    $"/DD/DItems[@DValue='nation']/DItem[@DValue='{student.nation}']", "Text");
            }
            if (student.politicstatus != null)
            {
                student.politicstatus = XmlHelper.GetOneByXPath("SimpleData.xml",
                $"/DD/DItems[@DValue='political']/DItem[@DValue='{student.politicstatus}']", "Text");
            }
            if (student.native_place != null)
            {

                string[] nativePlace = student.native_place.Split('-');
                if (nativePlace.Length != 3)
                    student.native_place = "";
                else
                {
                    string province = XmlHelper.GetOneByXPath("Provinces.xml",
                    $"/Provinces/Province[@ID='{nativePlace[0]}']", "ProvinceName");
                    string city = XmlHelper.GetOneByXPath("Cities.xml",
                    $"/Cities/City[@PID='{nativePlace[0]}' and @ID='{nativePlace[1]}']", "CityName");
                    string districts = XmlHelper.GetOneByXPath("Districts.xml",
                    $"/Districts/District[@CID='{nativePlace[1]}' and @ID='{nativePlace[2]}']", "DistrictName");
                    student.native_place = province + city + districts;
                }
            }

            return student;


        }

        public PartialViewResult GetStudentData(int page = 1, string type = "", string searchContext = "")
        {
            int total = 0;
            IEnumerable<td_students> result = null;
            if (type != "" && searchContext != "")
            {
                result = Search(type, searchContext);
                result =
                    result.OrderByDescending(p => p.audit)
                        .ThenBy(p => p.school_code)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize);
                total = result.Count();
            }
            else
            {
                result = StudentService.GetPageEntites(PageSize, page, out total, u => true, t =>
                t.school_code, true).OrderBy(u=>u.audit);
            }
            if (result.Count() == 0)
            {
                TempData["ErrorMsg"] = "未查询到任何结果，请修改查询条件";
                return PartialView();
            }

            StudentListViewModel model = new StudentListViewModel
            {
                Students = result,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = total
                }
            };
            return PartialView(model);
        }
        private IEnumerable<td_students> Search(string type, string searchContext)
        {
            IEnumerable<td_students> result = null;
            if (type == "dormitory")
            {
                result = StudentService.GetEntities(m => m.dormitory.Contains(searchContext));
            }
            if (type == "schoolCode")
            {
                result = StudentService.GetEntities(m => m.school_code.Equals(searchContext));
            }
            if (type == "studentName")
            {
                result = StudentService.GetEntities(m => m.student_name.Contains(searchContext));
            }
            return result;
        }

        //处理删除审核锁定操作
        public ActionResult Deal(string studentId, string action)
        {
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(action))
            {
                TempData["DealErrMsg"] = "操作失败";
                return GetStudentData();
            }
            switch (action)
            {
                case "删除":
                    StudentService.Delete(studentId);
                    break;
                case "审核":
                    StudentService.Audit(studentId);
                    break;
                case "锁定":
                    StudentService.Lock(studentId);
                    break;
                default:
                    break;
            }
            TempData["DealErrMsg"] = "操作成功";
            return RedirectToAction("GetStudentData");
        }

        private StudnetEditViewModel GetInitStudentEditModel()
        {
            StudnetEditViewModel model = new StudnetEditViewModel
            {
                Student = new td_students(),
                Banjis = XmlHelper.GetListByXpath("SimpleData.xml", "/DD/DItems[@DValue='banji']", ""),
                Depts = XmlHelper.GetListByXpath("deptlist.xml", "/Departments", "", "Dept_name", "Dept_code"),
                Genders = XmlHelper.GetListByXpath("SimpleData.xml", "/DD/DItems[@DValue='gender']", ""),
                Grades = XmlHelper.GetListByXpath("SimpleData.xml", "/DD/DItems[@DValue='grade']", ""),
                Majors = new List<SelectListItem>(),
                Nation = XmlHelper.GetListByXpath("SimpleData.xml", "/DD/DItems[@DValue='nation']", ""),
                Politicstatus = XmlHelper.GetListByXpath("SimpleData.xml", "/DD/DItems[@DValue='political']", ""),
                Proviences = XmlHelper.GetListByXpath("Provinces.xml", "/Provinces", "", "ProvinceName", "ID"),
                Cities = new List<SelectListItem>(),
                Districts = new List<SelectListItem>()

            };
            return model;
        }
        private StudnetEditViewModel GetSutdentEditModel(string Id)
        {
            td_students student = StudentService.GetEntities(p => p.id == Id).FirstOrDefault();
            StudnetEditViewModel model = null;
            if (student == null)
            {
                model = GetInitStudentEditModel();
            }
            else
            {
                model = new StudnetEditViewModel
                {
                    Student = student,
                    Banjis = XmlHelper.GetListByXpath("banji", student.banji),
                    Depts = XmlHelper.GetListByXpath("deptlist.xml", "/Departments", student.dept, "Dept_name", "Dept_code"),
                    Genders = XmlHelper.GetListByXpath("gender", student.gender),
                    Grades = XmlHelper.GetListByXpath("grade", student.grade),
                    Majors = XmlHelper.GetListByXpath("Major.xml", string.Format("/Majors/DItems[@DValue='{0}']", student.dept), student.major),
                    Nation = XmlHelper.GetListByXpath("nation", student.nation),
                    Politicstatus = XmlHelper.GetListByXpath("political", student.politicstatus)
                };
                string[] nativePlaces = string.IsNullOrEmpty(student.native_place) ? null : student.native_place.Split('-');
                if (nativePlaces != null)
                {
                    model.Proviences = XmlHelper.GetListByXpath("Provinces.xml", "/Provinces", nativePlaces[0], "ProvinceName", "ID");
                    model.Cities = XmlHelper.GetListByXpath("Cities.xml", string.Format("/Cities/*[@PID='{0}']", nativePlaces[0]), nativePlaces[1], "CityName", "ID", false);
                    model.Districts = XmlHelper.GetListByXpath("Districts.xml", string.Format("/Districts/*[@CID='{0}']", nativePlaces[1]), nativePlaces[2], "DistrictName", "ID", false);
                }
                else
                {
                    model.Proviences = XmlHelper.GetListByXpath("Provinces.xml", "/Provinces", "", "ProvinceName", "ID");
                    model.Cities = new List<SelectListItem>();
                    model.Districts = new List<SelectListItem>();
                }
            }

            return model;
        }

        //异步刷新班级ddl
        public JsonResult GetJsonDataToBanji(string gradeText, string majorText)
        {
            string gradeCode = "", majorCode = "";
            if (!string.IsNullOrEmpty(gradeText))
                gradeCode = gradeText;/*.Substring(2,2)*/
            if (!string.IsNullOrEmpty(majorText)) { }
            majorCode = majorText.Contains("计") ? "计科" : "电信";
            IEnumerable<SelectListItem> banjiList = XmlHelper.GetListByXpath("banji");
            banjiList = from target in banjiList
                        where target.Text.Contains(gradeCode) && target.Text.Contains(majorCode)
                        select target;
            return Json(banjiList, JsonRequestBehavior.AllowGet);

        }
        //异步刷新省市
        public JsonResult GetNativePlaceData(string fatherElemValue, string childElemName)
        {
            string filter = "";
            IEnumerable<SelectListItem> result = null;
            childElemName = childElemName.ToLower();
            switch (childElemName)
            {
                case "city":
                    filter = string.Format("/Cities/*[@PID='{0}']", fatherElemValue);
                    result = XmlHelper.GetListByXpath("Cities.xml", filter, "", "CityName", "ID", false);
                    break;
                case "district":
                    filter = string.Format("/Districts/*[@CID='{0}']", fatherElemValue);
                    result = XmlHelper.GetListByXpath("Districts.xml", filter, "", "DistrictName", "ID", false);
                    break;
                case "major":
                    filter = string.Format("/Majors/DItems[@DValue='{0}']", fatherElemValue);
                    result = XmlHelper.GetListByXpath("Major.xml", filter, "");
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}