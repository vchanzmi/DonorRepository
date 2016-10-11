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
    public class SponsorshipController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sponsorship
        public ActionResult Index()
        {
            var sponsorship = db.Sponsorships.Include(d => d.Donor).Include(d => d.Recipient);
            return View(sponsorship.ToList());
        }

        // GET: Sponsorship/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsorship sponsorship = db.Sponsorships.Find(id);
            if (sponsorship == null)
            {
                return HttpNotFound();
            }
            return View(sponsorship);
        }

        // GET: Sponsorship/Create
        public ActionResult Sponsor()
        {
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "FirstName");
            ViewBag.RecipientId = new SelectList(db.Recipients, "RecipientId", "EnglishName");
            return View();
        }

        // POST: Sponsorship/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sponsor([Bind(Include = "DonorId,RecipientId,Amount,Frequency,StartDate,EndDate")] Sponsorship sponsorship)
        {
            if (ModelState.IsValid)
            {
                db.Sponsorships.Add(sponsorship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "FirstName", sponsorship.DonorId);
            ViewBag.RecipientId = new SelectList(db.Recipients, "RecipientId", "EnglishName", sponsorship.RecipientId);
            return View(sponsorship);
        }

        // GET: Sponsorship/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsorship donorRecipient = db.Sponsorships.Find(id);
            if (donorRecipient == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "FirstName", donorRecipient.DonorId);
            ViewBag.RecipientId = new SelectList(db.Recipients, "RecipientId", "EnglishName", donorRecipient.RecipientId);
            return View(donorRecipient);
        }

        // POST: Sponsorship/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorId,RecipientId,Amount,Frequency,StartDate,EndDate")] Sponsorship donorRecipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorRecipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "FirstName", donorRecipient.DonorId);
            ViewBag.RecipientId = new SelectList(db.Recipients, "RecipientId", "EnglishName", donorRecipient.RecipientId);
            return View(donorRecipient);
        }

        // GET: Sponsorship/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsorship donorRecipient = db.Sponsorships.Find(id);
            if (donorRecipient == null)
            {
                return HttpNotFound();
            }
            return View(donorRecipient);
        }

        // POST: Sponsorship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsorship donorRecipient = db.Sponsorships.Find(id);
            db.Sponsorships.Remove(donorRecipient);
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
