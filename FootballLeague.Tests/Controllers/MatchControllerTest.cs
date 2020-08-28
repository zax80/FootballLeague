using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballLeague.Controllers;
using System.Web.Mvc;
using FootballLeague.Models;

namespace FootballLeague.Tests.Controllers
{
    /// <summary>
    /// Summary description for MatchControllerTest
    /// </summary>
    [TestClass]
    public class MatchControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            MatchController controller = new MatchController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
