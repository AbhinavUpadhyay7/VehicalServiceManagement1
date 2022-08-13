using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicalServiceManagement1;

namespace VehicalServiceManagement1.Controllers
{
   [Authorize]
    public class SerCentersController : Controller
    {
        private ServiceCenterEntities db = new ServiceCenterEntities();

        // GET: SerCenters
        public ActionResult Index()
        {
            return View(db.SerCenter.ToList());
        }

        // GET: SerCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SerCenter serCenter = db.SerCenter.Find(id);
            if (serCenter == null)
            {
                return HttpNotFound();
            }
            return View(serCenter);
        }

        // GET: SerCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SerCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceCenterID,ServiceCenterName,AppBookDate,VehicalType,VehicalModel")] SerCenter serCenter)
        {
            if (ModelState.IsValid)
            {
                db.SerCenter.Add(serCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serCenter);
        }

        // GET: SerCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SerCenter serCenter = db.SerCenter.Find(id);
            if (serCenter == null)
            {
                return HttpNotFound();
            }
            return View(serCenter);
        }

        // POST: SerCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceCenterID,ServiceCenterName,AppBookDate,VehicalType,VehicalModel")] SerCenter serCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serCenter);
        }

        // GET: SerCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SerCenter serCenter = db.SerCenter.Find(id);
            if (serCenter == null)
            {
                return HttpNotFound();
            }
            return View(serCenter);
        }

        // POST: SerCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SerCenter serCenter = db.SerCenter.Find(id);
            db.SerCenter.Remove(serCenter);
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
