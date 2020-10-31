using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Net;
using CFPPE.Models;

namespace CFPPE.Controllers
{
    public class AlumnosController : Controller
    {
        private plataformaEntities db = new plataformaEntities();

        // GET: Alumnos        
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.perfil).Include(u => u.seccion);
            return View(usuario.ToList());
        }

        public ActionResult MasterPageAl()
        {

            return View();
        }

        // GET: RegUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
            return View(usuario);
        }

        // POST: RegUser/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
            return View(usuario);
        }
    }
}