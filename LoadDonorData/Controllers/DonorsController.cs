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
    public class DonorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Donors
        public ActionResult Index()
        {
            var donors = db.Donors.Include(d => d.Payer).Include(d => d.Church);
            return View(db.Donors.ToList());
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonorId,Title,FirstName,MI,LastName,Nickname,ChineseName,Suffix,HomePhone,CellPhone,Email1,Email2,AddressLine1,AddressLine2,City,State,ZipCode,Country,DOB,ContactMethod,Branch,Solicitation,InterestedProjects,Notes")] Donor donor)
        {
            
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donor);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorId,Title,FirstName,MI,LastName,Nickname,ChineseName,Suffix,HomePhone,CellPhone,Email1,Email2,AddressLine1,AddressLine2,City,State,ZipCode,Country,DOB,ContactMethod,Branch,Solicitation,Notes")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
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

        // GET: Donors/InterestedProjects
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult InterestedProjects()
        {
            var list = new List<InterestedProjects>
            {
                 new InterestedProjects{IdNum = 1, TextName = "Hope House", CheckedYet = false},
                 new InterestedProjects{IdNum = 2, TextName = "Village Aid", CheckedYet = false},
                 new InterestedProjects{IdNum = 3, TextName = "Angels Tour", CheckedYet = false},
                 new InterestedProjects{IdNum = 4, TextName = "Project Orphan Blessing", CheckedYet = false},
                 new InterestedProjects{IdNum = 5, TextName = "English Summer Camp", CheckedYet = false},
                 new InterestedProjects{IdNum = 6, TextName = "Senior Care", CheckedYet = false},
            };
        }
    }
}
