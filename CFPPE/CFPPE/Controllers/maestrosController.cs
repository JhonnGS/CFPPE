using CFPPE.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
      /*  public ActionResult Create()
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
        }*/

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

        public ActionResult CreateActividades()
        {
           
            ViewBag.idAlumno = new SelectList(db.alumnos, "idAlumno", "Nombre");
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "Materia");
            ViewBag.idMaestro = new SelectList(db.maestros, "idMaestro", "Nombre");

           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActividades([Bind(Include = "idActividad,idAlumno,idMateria,NombreA,Tema,Calificacion,FechaInicio,FechaEntrega,Detalle,TempoActividad,ValorA,idMaestro")] actividades actividad)
        {
            if (ModelState.IsValid)
            {
                db.actividades.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlumno = new SelectList(db.alumnos, "idAlumno", "Nombre", actividad.idAlumno);
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "Materia", actividad.idMateria);
            ViewBag.idMaestro = new SelectList(db.maestros, "idMaestro", "Nombre",actividad.idMaestro);
            
            // ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(actividad);
        }

        public ActionResult CreateMateria()
        {
           
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
            ViewBag.idMaestro = new SelectList(db.maestros, "idMaestro", "Nombre");
            ViewBag.idTipoMateria = new SelectList(db.tipomateria, "idTipoMateria", "Nombre");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMateria([Bind(Include = "idMateria,idSeccion,idMaestro,Materia,CodigoM,FechaIN,FechaFI,Descripcion,Status,Grado,Grupo,idTipoMateria")] materia mater)
        {
            if (ModelState.IsValid)
            {
                db.materia.Add(mater);
                 db.SaveChanges();
                return RedirectToAction("Index");
                 
            }
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", mater.idSeccion);
            ViewBag.idMaestro = new SelectList(db.maestros, "idMaestro", "Nombre", mater.idMaestro);
            ViewBag.idTipoMateria = new SelectList(db.tipomateria, "idTipoMateria", "Nombre", mater.idTipoMateria);
           
            return View(mater);
        }


        public ActionResult CreateTarea()
        {
            
            ViewBag.idAlumno = new SelectList(db.alumnos, "idAlumno", "Nombre");
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "Materia");
            ViewBag.idMaestro = new SelectList(db.maestros, "idMateria", "Nombre");

            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTarea([Bind(Include = "idTarea,idAlumno,idMateria,idMaestro,NombreT,Tema,CalificacionA,CalificacionR,FechaInicio,Fecha_E,Detalle,Archivo")] tareas tarea)
        {
            if (ModelState.IsValid)
            {
                db.tareas.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlumno = new SelectList(db.alumnos, "idAlumno", "Nombre", tarea.idAlumno);
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "Materia", tarea.idMateria);
            ViewBag.idMaestro = new SelectList(db.maestros, "idMateria", "Nombre", tarea.idMaestro);

            // ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "Nombre", maestros.idUsuario);
            return View(tarea);
        }
    }
}
