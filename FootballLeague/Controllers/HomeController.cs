using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeagueEntities db = new LeagueEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.LeagueStats());
        }
    }
}