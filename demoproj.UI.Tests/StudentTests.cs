using System;
using System.Collections.Generic;
using demoprojMVC.BLL;
using demoprojMVC.Common;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using demoprojMVC.Model.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace demoproj.UI.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Test_Get_Page_StudnetInfo()
        {
            Mock<Itd_studentsService> mock = new Mock<Itd_studentsService>();
            td_students student = new td_students
            {
                id = "1",
                school_code = "1",
                student_name = "s1"
            };
            //StudentInfoController target = new StudentInfoController(mock.Object);
            //StudentListViewModel result =  (target.GetStudentData()).Model as StudentListViewModel;
            mock.Verify(m=>m.Update(student));
        }
        [TestMethod]
        public void Can_Add_UserInfo()
        {
            //Mock<UserInfoService> mock = new Mock<UserInfoService>();
            short DelFlag = (short) DelFlagEnum.Normal;
            UserInfoService service = new UserInfoService();
            UserInfo info = new UserInfo {ID = TableIDCodingRule.newID("userinfo",""),UName = "admin",Pwd = "123",ModfiedOn = DateTime.Now,SubTime = DateTime.Now,DelFlag = DelFlag,ShowName = "管理员"};
            service.Add(info);
        }
    }
}
