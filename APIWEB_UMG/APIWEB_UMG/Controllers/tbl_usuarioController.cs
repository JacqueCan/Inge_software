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
    public class tbl_usuarioController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_usuario
        public ActionResult Index()
        {
            var tbl_usuario = db.tbl_usuario.Include(t => t.tbl_persona).Include(t => t.tbl_tipoPersona);
            return View(tbl_usuario.ToList());
        }

        // GET: tbl_usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // GET: tbl_usuario/Create
        public ActionResult Create()
        {
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre");
            ViewBag.Tipo_Persona = new SelectList(db.tbl_tipoPersona, "Id_Tpersona", "Id_Tpersona");
            return View();
        }

        // POST: tbl_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Usuario,Tipo_Persona,Usuario,Contrasena,Persona")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tbl_usuario.Add(tbl_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_usuario.Persona);
            ViewBag.Tipo_Persona = new SelectList(db.tbl_tipoPersona, "Id_Tpersona", "Id_Tpersona", tbl_usuario.Tipo_Persona);
            return View(tbl_usuario);
        }

        // GET: tbl_usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_usuario.Persona);
            ViewBag.Tipo_Persona = new SelectList(db.tbl_tipoPersona, "Id_Tpersona", "Id_Tpersona", tbl_usuario.Tipo_Persona);
            return View(tbl_usuario);
        }

        // POST: tbl_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Usuario,Tipo_Persona,Usuario,Contrasena,Persona")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Persona = new SelectList(db.tbl_persona, "Id_Persona", "Nombre", tbl_usuario.Persona);
            ViewBag.Tipo_Persona = new SelectList(db.tbl_tipoPersona, "Id_Tpersona", "Id_Tpersona", tbl_usuario.Tipo_Persona);
            return View(tbl_usuario);
        }

        // GET: tbl_usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // POST: tbl_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            db.tbl_usuario.Remove(tbl_usuario);
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
