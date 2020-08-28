using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballLeague.Models;

namespace FootballLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly LeagueEntities db = new LeagueEntities();

        // GET: Matche
        [HttpGet]
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.Team).Include(m => m.Team1);
            return View(matches.ToList());
        }

        // GET: Matche/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matche/Create
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.HomeTeam = new SelectList(db.Teams, "Id", "Name");
            ViewBag.AwayTeam = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Matche/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Date,HomeTeam,AwayTeam,HomeScore,AwayScore")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomeTeam = new SelectList(db.Teams, "Id", "Name", match.HomeTeam);
            ViewBag.AwayTeam = new SelectList(db.Teams, "Id", "Name", match.AwayTeam);
            return View(match);
        }

        // GET: Matche/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeTeam = new SelectList(db.Teams, "Id", "Name", match.HomeTeam);
            ViewBag.AwayTeam = new SelectList(db.Teams, "Id", "Name", match.AwayTeam);
            return View(match);
        }

        // POST: Matche/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Date,HomeTeam,AwayTeam,HomeScore,AwayScore")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomeTeam = new SelectList(db.Teams, "Id", "Name", match.HomeTeam);
            ViewBag.AwayTeam = new SelectList(db.Teams, "Id", "Name", match.AwayTeam);
            return View(match);
        }

        // GET: Matche/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
