using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using footballnet.Data;
using footballnet.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace footballnet.Controllers
{
    public class GamesController : Controller
    {
        private FootballContext db = new FootballContext();

        public ActionResult DeleteAll()
        {
            db.Player.RemoveRange(db.Player);
            db.PlayerRecord.RemoveRange(db.PlayerRecord);
            db.PlayerNr.RemoveRange(db.PlayerNr);
            db.PlayerNrRecord.RemoveRange(db.PlayerNrRecord);
            db.Penalty.RemoveRange(db.Penalty);
            db.PenaltyRecord.RemoveRange(db.PenaltyRecord);
            db.Goal.RemoveRange(db.Goal);
            db.GoalRecord.RemoveRange(db.GoalRecord);
            db.Change.RemoveRange(db.Change);
            db.ChangeRecord.RemoveRange(db.ChangeRecord);
            db.Referee.RemoveRange(db.Referee);
            db.Team.RemoveRange(db.Team);
            db.Game.RemoveRange(db.Game);

            db.SaveChanges();
            return View("Index", db.Game.ToList());
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in files.Where(f => f != null && f.ContentLength > 0))
                {
                    using (var fileStream = new StreamReader(file.InputStream))
                    {
                        var gameRecord = JsonConvert.DeserializeObject<GameRecord>(fileStream.ReadToEnd());

                        db.Game.Add(gameRecord.Spele);
                    }
                }
                db.SaveChanges();
            }


            return View("Index", db.Game.ToList());
        }

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Game.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Game.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Place,Spectators")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Game.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Game.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Place,Spectators")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Game.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Game.Find(id);
            db.Game.Remove(game);
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
