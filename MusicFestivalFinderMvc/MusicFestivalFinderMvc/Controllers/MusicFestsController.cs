using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicFestivalFinderMvc.Models;

namespace MusicFestivalFinderMvc.Controllers
{
    public class MusicFestsController : Controller
    {
        private MusicFestivalDbEntities2 db = new MusicFestivalDbEntities2();

        // GET: MusicFests
        public ActionResult Index(string searchString)
        {
			var bands = from b in db.MusicFests
									select b;

			if (!String.IsNullOrEmpty(searchString))
			{
				bands = bands.Where(s => s.Band.Contains(searchString));
			}

			return View(bands);
		}


        // GET: MusicFests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicFest musicFest = db.MusicFests.Find(id);
            if (musicFest == null)
            {
                return HttpNotFound();
            }
            return View(musicFest);
        }

        // GET: MusicFests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicFests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Band,Festival,Location,DateStart,DateEnd")] MusicFest musicFest)
        {
            if (ModelState.IsValid)
            {
                db.MusicFests.Add(musicFest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicFest);
        }

        // GET: MusicFests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicFest musicFest = db.MusicFests.Find(id);
            if (musicFest == null)
            {
                return HttpNotFound();
            }
            return View(musicFest);
        }

        // POST: MusicFests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Band,Festival,Location,DateStart,DateEnd")] MusicFest musicFest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicFest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicFest);
        }

        // GET: MusicFests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicFest musicFest = db.MusicFests.Find(id);
            if (musicFest == null)
            {
                return HttpNotFound();
            }
            return View(musicFest);
        }

        // POST: MusicFests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicFest musicFest = db.MusicFests.Find(id);
            db.MusicFests.Remove(musicFest);
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
