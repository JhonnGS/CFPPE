using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CFPPE.Models;

namespace CFPPE.Controllers
{
    public class inscripcionsController : Controller
    {
        private plataformaEntities db = new plataformaEntities();

        // GET: inscripcions
        public ActionResult Index()
        {
            return View(db.inscripcion.ToList());
        }

        // GET: inscripcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inscripcion inscripcion = db.inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: inscripcions/Create
        public ActionResult Create()
        {
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
            return View();
        }

        // POST: inscripcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInscripcion,Nombre,FechaNac,FechaInscripcion,Edad,idSeccion,Grado,Grupo,AlergiasEnfermedad,Observacion,NombreT,Ocupacion,Direccion,TelCasa,TelTrabajo,Telefono")] inscripcion Inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.inscripcion.Add(Inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
            return View(Inscripcion);
        }

        // GET: inscripcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inscripcion inscripcion = db.inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: inscripcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInscripcion,Nombre,FechaNac,FechaInscripcion,Edad,idSeccion,Grado,Grupo,AlergiasEnfermedad,Observacion,NombreT,Ocupacion,Direccion,TelCasa,TelTrabajo,Telefono")] inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inscripcion);
        }

        // GET: inscripcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inscripcion inscripcion = db.inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inscripcion inscripcion = db.inscripcion.Find(id);
            db.inscripcion.Remove(inscripcion);
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
