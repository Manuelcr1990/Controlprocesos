using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Controlprocesos.Model;
using Controlprocesos.Models;
using Microsoft.AspNet.Identity.Owin;
using Controlprocesos.Enums;

namespace Controlprocesos.Controllers {
    [Authorize]
    public class ODPProcessesController : Controller {

        private CP db = new CP();

        // GET: ODPProcesses
        public ActionResult Index() {
            var oDPProcesses = db.ODPProcesses.Include(o => o.ODP).Include(o => o.Process);
            return View(oDPProcesses.ToList());
        }

        // GET: ODPProcesses/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODPProcess oDPProcess = db.ODPProcesses.Find(id);
            if (oDPProcess == null) {
                return HttpNotFound();
            }
            return View(oDPProcess);
        }

        [HttpPost]
        public ActionResult ChangeODPProcessStatus(int ODPProcessId, int status) {
            var item = db.ODPProcesses.Find(ODPProcessId);
            if (item == null) return HttpNotFound();
            item.Status = Convert.ToByte(status);
            db.SaveChanges();
            return RedirectToAction("Index", "ODPProcesses");
        }

        // GET: ODPProcesses/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create() {
            ViewBag.ODPId = new SelectList(db.ODPs, "Id", "NODP");
            ViewBag.ProcessId = new SelectList(db.Processes, "Id", "Title");
            ViewBag.UserId = new SelectList(db.vwUsers, "Id", "Username");
            ViewBag.Status = new SelectList(ODPProcessStatus.GetList(), "Value", "Name");
            return View();
        }

        // POST: ODPProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "Id,ODPId,ProcessId,UserId,Status,Notes")] ODPProcess oDPProcess) {
            if (ModelState.IsValid) {
                db.ODPProcesses.Add(oDPProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ODPId = new SelectList(db.ODPs, "Id", "NODP", oDPProcess.ODPId);
            ViewBag.ProcessId = new SelectList(db.Processes, "Id", "Title", oDPProcess.ProcessId);
            return View(oDPProcess);
        }

        // GET: ODPProcesses/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODPProcess oDPProcess = db.ODPProcesses.Find(id);
            if (oDPProcess == null) {
                return HttpNotFound();
            }
            ViewBag.ODPId = new SelectList(db.ODPs, "Id", "NODP", oDPProcess.ODPId);
            ViewBag.ProcessId = new SelectList(db.Processes, "Id", "Title", oDPProcess.ProcessId);
            ViewBag.UserId = new SelectList(db.vwUsers, "Id", "Username", oDPProcess.UserId);
            ViewBag.Status = new SelectList(ODPProcessStatus.GetList(), "Value", "Name", oDPProcess.Status);
            return View(oDPProcess);
        }

        // POST: ODPProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ODPId,ProcessId,UserId,Status,Notes")] ODPProcess oDPProcess) {
            if (ModelState.IsValid) {
                db.Entry(oDPProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ODPId = new SelectList(db.ODPs, "Id", "NODP", oDPProcess.ODPId);
            ViewBag.ProcessId = new SelectList(db.Processes, "Id", "Title", oDPProcess.ProcessId);
            return View(oDPProcess);
        }

        // GET: ODPProcesses/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODPProcess oDPProcess = db.ODPProcesses.Find(id);
            if (oDPProcess == null) {
                return HttpNotFound();
            }
            return View(oDPProcess);
        }

        // POST: ODPProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            ODPProcess oDPProcess = db.ODPProcesses.Find(id);
            db.ODPProcesses.Remove(oDPProcess);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
