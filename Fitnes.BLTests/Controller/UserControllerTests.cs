using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitnes.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {      
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthday = DateTime.Now.AddYears(- 18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);
            controller.SetNewUserData(userName, birthday, weight, height);
            var controller2 = new UserController(userName);
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var controller = new UserController(userName);
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}