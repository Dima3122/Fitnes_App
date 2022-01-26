using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitnes.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnes.BL.Model;

namespace Fitnes.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingConroller = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            eatingConroller.Add(food, 100);
            Assert.AreEqual(food.Name, eatingConroller.Eating.Foods.First().Key.Name);
        }
    }
}