using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Models;

namespace WebApplication_美學ch06.Controllers
{
    public class Customer1Controller : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Customer1
        public ActionResult Index()
        {
            return View(db.Customer1.ToList());
        }

        // GET: Customer1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer1 customer1 = db.Customer1.Find(id);
            if (customer1 == null)
            {
                return HttpNotFound();
            }
            return View(customer1);
        }

        // GET: Customer1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Email2,Birthday")] Customer1 customer1)
        {
            if (ModelState.IsValid)
            {
                db.Customer1.Add(customer1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer1);
        }

        // GET: Customer1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer1 customer1 = db.Customer1.Find(id);
            if (customer1 == null)
            {
                return HttpNotFound();
            }
            return View(customer1);
        }

        // POST: Customer1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Email2,Birthday")] Customer1 customer1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer1);
        }

        // GET: Customer1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer1 customer1 = db.Customer1.Find(id);
            if (customer1 == null)
            {
                return HttpNotFound();
            }
            return View(customer1);
        }

        // POST: Customer1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer1 customer1 = db.Customer1.Find(id);
            db.Customer1.Remove(customer1);
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
