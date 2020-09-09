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
    public class alumnosController : Controller
    {
        private plataformaEntities db = new plataformaEntities();

        // GET: alumnos
        public ActionResult Index()
        {
            var alumnos = db.alumnos.Include(a => a.usuario);
            return View(alumnos.ToList());
        }

        // GET: alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: alumnos/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre");
            return View();
        }

        // POST: alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlumno,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idUsuario")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.alumnos.Add(alumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", alumnos.idUsuario);
            return View(alumnos);
        }

        // GET: alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", alumnos.idUsuario);
            return View(alumnos);
        }

        // POST: alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlumno,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idUsuario")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", alumnos.idUsuario);
            return View(alumnos);
        }

        // GET: alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alumnos alumnos = db.alumnos.Find(id);
            db.alumnos.Remove(alumnos);
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
