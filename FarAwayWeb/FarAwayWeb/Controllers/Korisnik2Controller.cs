using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarAwayWeb.Models;

namespace FarAwayWeb.Controllers
{
    public class Korisnik2Controller : Controller
    {
        private FarAwayContext db = new FarAwayContext();

        // GET: Korisnik2
        public ActionResult Index()
        {
            return View(db.Korisnik.ToList());
        }

        // GET: Korisnik2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik2 korisnik2 = db.Korisnik.Find(id);
            if (korisnik2 == null)
            {
                return HttpNotFound();
            }
            return View(korisnik2);
        }

        // GET: Korisnik2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnik2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Prezime,DRodjenja,Email,Username,Password")] Korisnik2 korisnik2)
        {
            if (ModelState.IsValid)
            {
                db.Korisnik.Add(korisnik2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik2);
        }

        // GET: Korisnik2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik2 korisnik2 = db.Korisnik.Find(id);
            if (korisnik2 == null)
            {
                return HttpNotFound();
            }
            return View(korisnik2);
        }

        // POST: Korisnik2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Prezime,DRodjenja,Email,Username,Password")] Korisnik2 korisnik2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik2);
        }

        // GET: Korisnik2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik2 korisnik2 = db.Korisnik.Find(id);
            if (korisnik2 == null)
            {
                return HttpNotFound();
            }
            return View(korisnik2);
        }

        // POST: Korisnik2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik2 korisnik2 = db.Korisnik.Find(id);
            db.Korisnik.Remove(korisnik2);
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
