using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using programa.Models;

namespace programa.Controllers
{
    public class animalController : Controller
    {
        private programaContext db = new programaContext();

        //
        // GET: /animal/

        public ActionResult Index()
        {
            return View(db.animals.ToList());
        }

        //
        // GET: /animal/Details/5

        public ActionResult Details(int id = 0)
        {
            animal animal = db.animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        //
        // GET: /animal/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /animal/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(animal animal)
        {
            if (ModelState.IsValid)
            {
                db.animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal);
        }

        //
        // GET: /animal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            animal animal = db.animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        //
        // POST: /animal/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        //
        // GET: /animal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            animal animal = db.animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        //
        // POST: /animal/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            animal animal = db.animals.Find(id);
            db.animals.Remove(animal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}