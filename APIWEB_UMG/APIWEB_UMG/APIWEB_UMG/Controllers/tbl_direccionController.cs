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
    public class tbl_direccionController : Controller
    {
        private EntregaEntities db = new EntregaEntities();

        // GET: tbl_direccion
        public ActionResult Index()
        {
            return View(db.tbl_direccion.ToList());
        }

        // GET: tbl_direccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_direccion tbl_direccion = db.tbl_direccion.Find(id);
            if (tbl_direccion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_direccion);
        }

        // GET: tbl_direccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_direccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Direccion,No_Casa,Calle,Avenida,Colonia,Municipio,Departamento,Pais,Descripcion")] tbl_direccion tbl_direccion)
        {
            if (ModelState.IsValid)
            {
                db.tbl_direccion.Add(tbl_direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_direccion);
        }

        // GET: tbl_direccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_direccion tbl_direccion = db.tbl_direccion.Find(id);
            if (tbl_direccion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_direccion);
        }

        // POST: tbl_direccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Direccion,No_Casa,Calle,Avenida,Colonia,Municipio,Departamento,Pais,Descripcion")] tbl_direccion tbl_direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_direccion);
        }

        // GET: tbl_direccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_direccion tbl_direccion = db.tbl_direccion.Find(id);
            if (tbl_direccion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_direccion);
        }

        // POST: tbl_direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_direccion tbl_direccion = db.tbl_direccion.Find(id);
            db.tbl_direccion.Remove(tbl_direccion);
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
