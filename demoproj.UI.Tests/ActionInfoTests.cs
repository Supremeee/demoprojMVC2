using System;
using System.Collections.Generic;
using System.Linq;
using demoprojMVC.BLL;
using demoprojMVC.Common;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using demoprojMVC.Model.Enum;
using demoprojMVC.UI.Portal.Controllers;
using demoprojMVC.UI.Portal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace demoproj.UI.Tests
{
    [TestClass]
    public class ActionInfoTests
    {
        [TestMethod]
        public void Can_Add_ActionInfo()
        {
            ActionInfo model = new ActionInfo
            {
                ID = TableIDCodingRule.newID("actioninfo", ""),
                ActionName = "学生信息管理",
                HttpMethd = "Get",
                IsMenu = true,
                DelFlag = (short)DelFlagEnum.Normal,
                ModfiedOn = DateTime.Now,
                SubTime = DateTime.Now,
                Sort = 1,
                Url = "ActionInfo/Index"

            };
            //IActionInfoService target = new ActionInfoService();
            //target.Add(model);
            Mock<IActionInfoService> mock = new Mock<IActionInfoService>();
            //ActionInfoController target = new ActionInfoController(mock.Object);
            //target.Edit(model);
            mock.Verify(u => u.Add(model), Times.Once);
        }
        [TestMethod]
        public void Can_Get_All_ActionInfo()
        {
            ActionInfo[] models = {new ActionInfo {ID = "s1",ActionName = "test1",HttpMethd = "Post"},
                new ActionInfo {ID = "s2",ActionName = "test2",HttpMethd = "Post"},
                new ActionInfo {ID = "s3",ActionName = "test3",HttpMethd = "Post"},
                new ActionInfo {ID = "s4",ActionName = "test4",HttpMethd = "Post"}};
            Mock<IActionInfoService> mock = new Mock<IActionInfoService>();
            mock.Setup(u => u.GetEntities(e => true)).Returns(models.AsQueryable());
            //ActionInfoController target = new ActionInfoController(mock.Object);
            //ActionInfoViewModel result = target.GetActionInfoData().Model as ActionInfoViewModel;
            //Assert.AreEqual(4, result.ActionInfos.Count());
        }

        [TestMethod]
        public void Can_Delete_By_Id()
        {
            IActionInfoService service = new ActionInfoService();

            ActionInfo target = service.GetEntities(u => u.ActionName.Contains("用户管理")).FirstOrDefault();
            if (target != null)
            {
                bool result = service.Delete(target.ID);
                Assert.AreEqual(true,result);
            }

        }
    }

   
}
