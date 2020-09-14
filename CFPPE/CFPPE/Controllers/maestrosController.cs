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
    public class maestrosController : Controller
    {
        private plataformaEntities db = new plataformaEntities();

        // GET: maestros
        public ActionResult Index()
        {
            var maestros = db.maestros.Include(m => m.usuario);
            return View(maestros.ToList());
        }

        // GET: maestros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maestros maestros = db.maestros.Find(id);
            if (maestros == null)
            {
                return HttpNotFound();
            }
            return View(maestros);
        }

        // GET: maestros/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre");
            return View();
        }

        // POST: maestros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMaestro,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idUsuario")] maestros maestros)
        {
            if (ModelState.IsValid)
            {
                db.maestros.Add(maestros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(maestros);
        }

        // GET: maestros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maestros maestros = db.maestros.Find(id);
            if (maestros == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(maestros);
        }

        // POST: maestros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMaestro,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idUsuario")] maestros maestros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maestros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(maestros);
        }

        // GET: maestros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maestros maestros = db.maestros.Find(id);
            if (maestros == null)
            {
                return HttpNotFound();
            }
            return View(maestros);
        }

        // POST: maestros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            maestros maestros = db.maestros.Find(id);
            db.maestros.Remove(maestros);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActividades([Bind(Include = "idActividad,idAlumno,idMateria,NombreA,Tema,Calificacion,FechaInicio,FechaEntrega,Detalle,TempoActividad,Valor,idMaestro")] actividades actividad)
        {
            if (ModelState.IsValid)
            {
                db.actividades.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(actividad);
        }

        public ActionResult CreateMateria([Bind(Include = "idMateria,idSeccion,idMaestro,Materia,CodigoM,FechaIN,FechaFI,Descripcion,Status,Grado,Grupo, idTipoMateria")] materia materia1)
        {
            if (ModelState.IsValid)
            {
                db.materia.Add(materia1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(materia1);
        }

        public ActionResult CreateTarea([Bind(Include = "idTarea,idAlumno,idMateria,idMaestro,NombreT,Tema,CalificacionA,CalificacionR,FechaInicio,Fecha_E,Detalle,Archivo")] tareas tarea)
        {
            if (ModelState.IsValid)
            {
                db.tareas.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(tarea);
        }
    }
}
