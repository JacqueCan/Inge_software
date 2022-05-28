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
    public class tbl_solicitudEntregaController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_solicitudEntrega
        public ActionResult Index()
        {
            var tbl_solicitudEntrega = db.tbl_solicitudEntrega.Include(t => t.tbl_direccion).Include(t => t.tbl_envio).Include(t => t.tbl_paquete).Include(t => t.tbl_persona).Include(t => t.tbl_recibe);
            return View(tbl_solicitudEntrega.ToList());
        }

        // GET: tbl_solicitudEntrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_solicitudEntrega tbl_solicitudEntrega = db.tbl_solicitudEntrega.Find(id);
            if (tbl_solicitudEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tbl_solicitudEntrega);
        }

        // GET: tbl_solicitudEntrega/Create
        public ActionResult Create()
        {
            ViewBag.Direccion_Entrega = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle");
            ViewBag.Ubicacion_Entrega = new SelectList(db.tbl_envio, "Id_Envio", "municipio");
            ViewBag.Tipo_Paquete = new SelectList(db.tbl_paquete, "Id_Paquete", "Tipo_Paquete");
            ViewBag.Persona_Envio = new SelectList(db.tbl_persona, "Id_Persona", "Nombre");
            ViewBag.Persona_Recibe = new SelectList(db.tbl_recibe, "Id_Recibe", "Nombre");
            return View();
        }

        // POST: tbl_solicitudEntrega/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Entrega,Persona_Envio,Tipo_Paquete,Descripcion_Paquete,Peso_Paquete,Persona_Recibe,Direccion_Entrega,Ubicacion_Entrega,Pago")] tbl_solicitudEntrega tbl_solicitudEntrega)
        {
            if (ModelState.IsValid)
            {
                db.tbl_solicitudEntrega.Add(tbl_solicitudEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Direccion_Entrega = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle", tbl_solicitudEntrega.Direccion_Entrega);
            ViewBag.Ubicacion_Entrega = new SelectList(db.tbl_envio, "Id_Envio", "municipio", tbl_solicitudEntrega.Ubicacion_Entrega);
            ViewBag.Tipo_Paquete = new SelectList(db.tbl_paquete, "Id_Paquete", "Tipo_Paquete", tbl_solicitudEntrega.Tipo_Paquete);
            ViewBag.Persona_Envio = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_solicitudEntrega.Persona_Envio);
            ViewBag.Persona_Recibe = new SelectList(db.tbl_recibe, "Id_Recibe", "Nombre", tbl_solicitudEntrega.Persona_Recibe);
            return View(tbl_solicitudEntrega);
        }

        // GET: tbl_solicitudEntrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_solicitudEntrega tbl_solicitudEntrega = db.tbl_solicitudEntrega.Find(id);
            if (tbl_solicitudEntrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.Direccion_Entrega = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle", tbl_solicitudEntrega.Direccion_Entrega);
            ViewBag.Ubicacion_Entrega = new SelectList(db.tbl_envio, "Id_Envio", "municipio", tbl_solicitudEntrega.Ubicacion_Entrega);
            ViewBag.Tipo_Paquete = new SelectList(db.tbl_paquete, "Id_Paquete", "Tipo_Paquete", tbl_solicitudEntrega.Tipo_Paquete);
            ViewBag.Persona_Envio = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_solicitudEntrega.Persona_Envio);
            ViewBag.Persona_Recibe = new SelectList(db.tbl_recibe, "Id_Recibe", "Nombre", tbl_solicitudEntrega.Persona_Recibe);
            return View(tbl_solicitudEntrega);
        }

        // POST: tbl_solicitudEntrega/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Entrega,Persona_Envio,Tipo_Paquete,Descripcion_Paquete,Peso_Paquete,Persona_Recibe,Direccion_Entrega,Ubicacion_Entrega,Pago")] tbl_solicitudEntrega tbl_solicitudEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_solicitudEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Direccion_Entrega = new SelectList(db.tbl_direccion, "Id_Direccion", "Calle", tbl_solicitudEntrega.Direccion_Entrega);
            ViewBag.Ubicacion_Entrega = new SelectList(db.tbl_envio, "Id_Envio", "municipio", tbl_solicitudEntrega.Ubicacion_Entrega);
            ViewBag.Tipo_Paquete = new SelectList(db.tbl_paquete, "Id_Paquete", "Tipo_Paquete", tbl_solicitudEntrega.Tipo_Paquete);
            ViewBag.Persona_Envio = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_solicitudEntrega.Persona_Envio);
            ViewBag.Persona_Recibe = new SelectList(db.tbl_recibe, "Id_Recibe", "Nombre", tbl_solicitudEntrega.Persona_Recibe);
            return View(tbl_solicitudEntrega);
        }

        // GET: tbl_solicitudEntrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_solicitudEntrega tbl_solicitudEntrega = db.tbl_solicitudEntrega.Find(id);
            if (tbl_solicitudEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tbl_solicitudEntrega);
        }

        // POST: tbl_solicitudEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_solicitudEntrega tbl_solicitudEntrega = db.tbl_solicitudEntrega.Find(id);
            db.tbl_solicitudEntrega.Remove(tbl_solicitudEntrega);
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
