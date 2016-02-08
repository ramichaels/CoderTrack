using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoderTrack;

namespace CoderTrack.Controllers
{
    public class MRNsController : Controller
    {
        private RJAssocEntities db = new RJAssocEntities();

        // GET: MRNs
        public ActionResult Index()
        {
            //var mRNs = db.MRNs.Include(m => m.Assessment).Include(m => m.Company).Include(m => m.Employee).Include(m => m.MRN11).Include(m => m.MRN2);
            var mRNs = db.MRNs;
            return View(mRNs.ToList());
        }

        // GET: MRNs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MRN mRN = db.MRNs.Find(id);
            if (mRN == null)
            {
                return HttpNotFound();
            }
            return View(mRN);
        }

        // GET: MRNs/Create
        public ActionResult Create()
        {
            ViewBag.AssessmentID = new SelectList(db.Assessments, "ID", "Description");
            ViewBag.CompanyCode = new SelectList(db.Companies, "CompanyCode", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fname");
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo");
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo");
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: MRNs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,ChartNo,CompanyCode,MRN1,AssessmentID,DateReceived,DateCompleted,TotalPay,EmployeeId,StatusId")] MRN mRN)
        {
            if (ModelState.IsValid)
            {
                db.MRNs.Add(mRN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssessmentID = new SelectList(db.Assessments, "ID", "Description", mRN.AssessmentID);
            ViewBag.CompanyCode = new SelectList(db.Companies, "CompanyCode", "Name", mRN.CompanyCode);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fname", mRN.EmployeeId);
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo", mRN.MRN1);
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo", mRN.MRN1);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View(mRN);
        }

        // GET: MRNs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MRN mRN = db.MRNs.Find(id);
            if (mRN == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssessmentID = new SelectList(db.Assessments, "ID", "Description", mRN.AssessmentID);
            ViewBag.CompanyCode = new SelectList(db.Companies, "CompanyCode", "Name", mRN.CompanyCode);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fname", mRN.EmployeeId);
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo", mRN.MRN1);
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo", mRN.MRN1);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View(mRN);
        }

        // POST: MRNs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,ChartNo,CompanyCode,MRN1,AssessmentID,DateReceived,DateCompleted,TotalPay,EmployeeId,StatusId")] MRN mRN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mRN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssessmentID = new SelectList(db.Assessments, "ID", "Description", mRN.AssessmentID);
            ViewBag.CompanyCode = new SelectList(db.Companies, "CompanyCode", "Name", mRN.CompanyCode);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fname", mRN.EmployeeId);
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo", mRN.MRN1);
            ViewBag.MRN1 = new SelectList(db.MRNs, "MRN1", "ChartNo", mRN.MRN1);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View(mRN);
        }

        // GET: MRNs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MRN mRN = db.MRNs.Find(id);
            if (mRN == null)
            {
                return HttpNotFound();
            }
            return View(mRN);
        }

        // POST: MRNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MRN mRN = db.MRNs.Find(id);
            db.MRNs.Remove(mRN);
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
