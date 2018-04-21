using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Controlprocesos.Model;

namespace Controlprocesos.Controllers
{
    public class ODPController : Controller
    {
        private CP db = new CP();

        // GET: ODP
        public ActionResult Index()
        {
            var oDPs = db.ODPs.Include(o => o.Client);
            return View(oDPs.ToList());
        }

        // GET: ODP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODP oDP = db.ODPs.Find(id);
            if (oDP == null)
            {
                return HttpNotFound();
            }
            return View(oDP);
        }

        // GET: ODP/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            return View();
        }

        // POST: ODP/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NODP,ClientId,Title,Notes,CreatedDate,DueDate,FinishedDate")] ODP oDP)
        {
            if (ModelState.IsValid)
            {
                db.ODPs.Add(oDP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", oDP.ClientId);
            return View(oDP);
        }

        // GET: ODP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODP oDP = db.ODPs.Find(id);
            if (oDP == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", oDP.ClientId);
            return View(oDP);
        }

        // POST: ODP/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NODP,ClientId,Title,Notes,CreatedDate,DueDate,FinishedDate")] ODP oDP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oDP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", oDP.ClientId);
            return View(oDP);
        }

        // GET: ODP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODP oDP = db.ODPs.Find(id);
            if (oDP == null)
            {
                return HttpNotFound();
            }
            return View(oDP);
        }

        // POST: ODP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ODP oDP = db.ODPs.Find(id);
            db.ODPs.Remove(oDP);
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
