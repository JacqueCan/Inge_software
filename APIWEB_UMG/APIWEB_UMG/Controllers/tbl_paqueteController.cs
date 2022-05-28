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
    public class tbl_paqueteController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_paquete
        public ActionResult Index()
        {
            return View(db.tbl_paquete.ToList());
        }

        // GET: tbl_paquete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_paquete tbl_paquete = db.tbl_paquete.Find(id);
            if (tbl_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tbl_paquete);
        }

        // GET: tbl_paquete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_paquete/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Paquete,Tipo_Paquete,Descripcion")] tbl_paquete tbl_paquete)
        {
            if (ModelState.IsValid)
            {
                db.tbl_paquete.Add(tbl_paquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_paquete);
        }

        // GET: tbl_paquete/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_paquete tbl_paquete = db.tbl_paquete.Find(id);
            if (tbl_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tbl_paquete);
        }

        // POST: tbl_paquete/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Paquete,Tipo_Paquete,Descripcion")] tbl_paquete tbl_paquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_paquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_paquete);
        }

        // GET: tbl_paquete/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_paquete tbl_paquete = db.tbl_paquete.Find(id);
            if (tbl_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tbl_paquete);
        }

        // POST: tbl_paquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_paquete tbl_paquete = db.tbl_paquete.Find(id);
            db.tbl_paquete.Remove(tbl_paquete);
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
