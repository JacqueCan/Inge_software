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
    public class tbl_personaController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_persona
        public ActionResult Index()
        {
            return View(db.tbl_persona.ToList());
        }

        // GET: tbl_persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_persona tbl_persona = db.tbl_persona.Find(id);
            if (tbl_persona == null)
            {
                return HttpNotFound();
            }
            return View(tbl_persona);
        }

        // GET: tbl_persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Persona,Nombre,Apellido,Telefono,Correo,DPI,Estado,Tipo_Persona")] tbl_persona tbl_persona)
        {
            if (ModelState.IsValid)
            {
                db.tbl_persona.Add(tbl_persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_persona);
        }

        // GET: tbl_persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_persona tbl_persona = db.tbl_persona.Find(id);
            if (tbl_persona == null)
            {
                return HttpNotFound();
            }
            return View(tbl_persona);
        }

        // POST: tbl_persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Persona,Nombre,Apellido,Telefono,Correo,DPI,Estado,Tipo_Persona")] tbl_persona tbl_persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_persona);
        }

        // GET: tbl_persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_persona tbl_persona = db.tbl_persona.Find(id);
            if (tbl_persona == null)
            {
                return HttpNotFound();
            }
            return View(tbl_persona);
        }

        // POST: tbl_persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_persona tbl_persona = db.tbl_persona.Find(id);
            db.tbl_persona.Remove(tbl_persona);
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
