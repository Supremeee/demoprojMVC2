using System;
using System.Linq;
using demoprojMVC.BLL;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demoproj.UI.Tests
{
    [TestClass]
    public class UserInfoTests
    {
        [TestMethod]
        public void Can_Delete_By_Id()
        {
            IUserInfoService service = new UserInfoService();

            UserInfo target = service.GetEntities(u => u.UName.Contains("test1")).FirstOrDefault();
            if (target != null)
            {
                bool result = service.Delete(target.ID);
                Assert.AreEqual(true, result);
            }

        }
    }
}
