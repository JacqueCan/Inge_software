using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APIWEB_UMG.Models;

namespace APIWEB_UMG.Controllers
{
    public class tbl_recibeController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_recibe
        public ActionResult Index()
        {
            return View(db.tbl_recibe.ToList());
        }

        // GET: tbl_recibe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_recibe tbl_recibe = db.tbl_recibe.Find(id);
            if (tbl_recibe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_recibe);
        }

        // GET: tbl_recibe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_recibe/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Recibe,Nombre,Apellido,Telefono")] tbl_recibe tbl_recibe)
        {
            if (ModelState.IsValid)
            {
                db.tbl_recibe.Add(tbl_recibe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_recibe);
        }

        // GET: tbl_recibe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_recibe tbl_recibe = db.tbl_recibe.Find(id);
            if (tbl_recibe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_recibe);
        }

        // POST: tbl_recibe/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Recibe,Nombre,Apellido,Telefono")] tbl_recibe tbl_recibe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_recibe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_recibe);
        }

        // GET: tbl_recibe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_recibe tbl_recibe = db.tbl_recibe.Find(id);
            if (tbl_recibe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_recibe);
        }

        // POST: tbl_recibe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_recibe tbl_recibe = db.tbl_recibe.Find(id);
            db.tbl_recibe.Remove(tbl_recibe);
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
