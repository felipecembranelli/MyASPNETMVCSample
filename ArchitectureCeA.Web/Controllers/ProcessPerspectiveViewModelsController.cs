using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArchitectureCeA.Data;
using ArchitectureCeA.Web.ViewModels;

namespace ArchitectureCeA.Web.Controllers
{
    public class ProcessPerspectiveViewModelsController : Controller
    {
        private ArchitectureCeAEntities db = new ArchitectureCeAEntities();

        // GET: ProcessPerspectiveViewModels
        public ActionResult Index()
        {
            return View(db.ProcessPerspectiveViewModels.ToList());
        }

        // GET: ProcessPerspectiveViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessPerspectiveViewModel processPerspectiveViewModel = db.ProcessPerspectiveViewModels.Find(id);
            if (processPerspectiveViewModel == null)
            {
                return HttpNotFound();
            }
            return View(processPerspectiveViewModel);
        }

        // GET: ProcessPerspectiveViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcessPerspectiveViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] ProcessPerspectiveViewModel processPerspectiveViewModel)
        {
            if (ModelState.IsValid)
            {
                db.ProcessPerspectiveViewModels.Add(processPerspectiveViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processPerspectiveViewModel);
        }

        // GET: ProcessPerspectiveViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessPerspectiveViewModel processPerspectiveViewModel = db.ProcessPerspectiveViewModels.Find(id);
            if (processPerspectiveViewModel == null)
            {
                return HttpNotFound();
            }
            return View(processPerspectiveViewModel);
        }

        // POST: ProcessPerspectiveViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ProcessPerspectiveViewModel processPerspectiveViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processPerspectiveViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processPerspectiveViewModel);
        }

        // GET: ProcessPerspectiveViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessPerspectiveViewModel processPerspectiveViewModel = db.ProcessPerspectiveViewModels.Find(id);
            if (processPerspectiveViewModel == null)
            {
                return HttpNotFound();
            }
            return View(processPerspectiveViewModel);
        }

        // POST: ProcessPerspectiveViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessPerspectiveViewModel processPerspectiveViewModel = db.ProcessPerspectiveViewModels.Find(id);
            db.ProcessPerspectiveViewModels.Remove(processPerspectiveViewModel);
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
