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
    public class tbl_tipoPersonaController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_tipoPersona
        public ActionResult Index()
        {
            return View(db.tbl_tipoPersona.ToList());
        }

        // GET: tbl_tipoPersona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipoPersona tbl_tipoPersona = db.tbl_tipoPersona.Find(id);
            if (tbl_tipoPersona == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipoPersona);
        }

        // GET: tbl_tipoPersona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_tipoPersona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tpersona,Tipo_Persona")] tbl_tipoPersona tbl_tipoPersona)
        {
            if (ModelState.IsValid)
            {
                db.tbl_tipoPersona.Add(tbl_tipoPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tipoPersona);
        }

        // GET: tbl_tipoPersona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipoPersona tbl_tipoPersona = db.tbl_tipoPersona.Find(id);
            if (tbl_tipoPersona == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipoPersona);
        }

        // POST: tbl_tipoPersona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tpersona,Tipo_Persona")] tbl_tipoPersona tbl_tipoPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tipoPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tipoPersona);
        }

        // GET: tbl_tipoPersona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipoPersona tbl_tipoPersona = db.tbl_tipoPersona.Find(id);
            if (tbl_tipoPersona == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipoPersona);
        }

        // POST: tbl_tipoPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_tipoPersona tbl_tipoPersona = db.tbl_tipoPersona.Find(id);
            db.tbl_tipoPersona.Remove(tbl_tipoPersona);
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
