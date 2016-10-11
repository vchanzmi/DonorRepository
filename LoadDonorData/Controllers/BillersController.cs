using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoadDonorData.Models;

namespace LoadDonorData.Controllers
{
    public class BillersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Billers
        public ActionResult Index()
        {
            return View(db.Billers.ToList());
        }

        // GET: Billers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biller biller = db.Billers.Find(id);
            if (biller == null)
            {
                return HttpNotFound();
            }
            return View(biller);
        }

        // GET: Billers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Billers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillerId,FirstName,MI,LastName,AddressLine1,City,State,ZipCode,Country,CreditCard4Digits,CreditCardType")] Biller biller)
        {
            if (ModelState.IsValid)
            {
                db.Billers.Add(biller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biller);
        }

        // GET: Billers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biller biller = db.Billers.Find(id);
            if (biller == null)
            {
                return HttpNotFound();
            }
            return View(biller);
        }

        // POST: Billers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillerId,FirstName,MI,LastName,AddressLine1,City,State,ZipCode,Country,CreditCard4Digits,CreditCardType")] Biller biller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biller);
        }

        // GET: Billers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biller biller = db.Billers.Find(id);
            if (biller == null)
            {
                return HttpNotFound();
            }
            return View(biller);
        }

        // POST: Billers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biller biller = db.Billers.Find(id);
            db.Billers.Remove(biller);
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
