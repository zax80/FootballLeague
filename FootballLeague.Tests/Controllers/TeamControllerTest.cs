using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballLeague.Controllers;
using System.Web.Mvc;

namespace FootballLeague.Tests.Controllers
{
    /// <summary>
    /// Summary description for TeamControllerTest
    /// </summary>
    [TestClass]
    public class TeamControllerTest
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            TeamController controller = new TeamController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
