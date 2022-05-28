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
    public class tbl_envioController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_envio
        public ActionResult Index()
        {
            var tbl_envio = db.tbl_envio.Include(t => t.tbl_direccion).Include(t => t.tbl_persona);
            return View(tbl_envio.ToList());
        }

        // GET: tbl_envio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_envio tbl_envio = db.tbl_envio.Find(id);
            if (tbl_envio == null)
            {
                return HttpNotFound();
            }
            return View(tbl_envio);
        }

        // GET: tbl_envio/Create
        public ActionResult Create()
        {
            ViewBag.Direccion = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle");
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre");
            return View();
        }

        // POST: tbl_envio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Envio,Persona,Direccion,municipio,departamento")] tbl_envio tbl_envio)
        {
            if (ModelState.IsValid)
            {
                db.tbl_envio.Add(tbl_envio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Direccion = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle", tbl_envio.Direccion);
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_envio.Persona);
            return View(tbl_envio);
        }

        // GET: tbl_envio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_envio tbl_envio = db.tbl_envio.Find(id);
            if (tbl_envio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Direccion = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle", tbl_envio.Direccion);
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_envio.Persona);
            return View(tbl_envio);
        }

        // POST: tbl_envio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Envio,Persona,Direccion,municipio,departamento")] tbl_envio tbl_envio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_envio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Direccion = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle", tbl_envio.Direccion);
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_envio.Persona);
            return View(tbl_envio);
        }

        // GET: tbl_envio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_envio tbl_envio = db.tbl_envio.Find(id);
            if (tbl_envio == null)
            {
                return HttpNotFound();
            }
            return View(tbl_envio);
        }

        // POST: tbl_envio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_envio tbl_envio = db.tbl_envio.Find(id);
            db.tbl_envio.Remove(tbl_envio);
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
