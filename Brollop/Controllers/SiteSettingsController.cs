using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Brollop;
using Brollop.Models.DbModels;

namespace Brollop.Controllers
{
    public class SiteSettingsController : Controller
    {
        private BrollopContext db = new BrollopContext();

        // GET: SiteSettings
        public ActionResult Index()
        {
            return View(db.SiteSettings.ToList());
        }

        // GET: SiteSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSetting siteSetting = db.SiteSettings.Find(id);
            if (siteSetting == null)
            {
                return HttpNotFound();
            }
            return View(siteSetting);
        }

        // GET: SiteSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OSA")] SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                db.SiteSettings.Add(siteSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteSetting);
        }

        // GET: SiteSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSetting siteSetting = db.SiteSettings.Find(id);
            if (siteSetting == null)
            {
                return HttpNotFound();
            }
            return View(siteSetting);
        }

        // POST: SiteSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OSA")] SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteSetting);
        }

        // GET: SiteSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSetting siteSetting = db.SiteSettings.Find(id);
            if (siteSetting == null)
            {
                return HttpNotFound();
            }
            return View(siteSetting);
        }

        // POST: SiteSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteSetting siteSetting = db.SiteSettings.Find(id);
            db.SiteSettings.Remove(siteSetting);
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
