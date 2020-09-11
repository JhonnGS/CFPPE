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
    public class RegUserController : Controller
    {
        private plataformaEntities db = new plataformaEntities();

        // GET: RegUser
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.perfil).Include(u => u.seccion);
            return View(usuario.ToList());
        }

        // GET: RegUser/Details/5
        public ActionResult Details(int? id)
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
            return View(usuario);
        }

        // GET: RegUser/Create
        public ActionResult Create()
        {
            ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP");
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
            return View();
        }

        // POST: RegUser/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
            ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
            return View(usuario);
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

        // GET: RegUser/Delete/5
        public ActionResult Delete(int? id)
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
            return View(usuario);
        }

        // POST: RegUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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

		// GET: RegUser/Create
		public ActionResult RegAl(int? mesg)
		{

			ViewBag.mensaje = mesg;

			if (ViewBag.mensaje != null)
			{
				ViewBag.mensaje = 1;
			}
			else
			{
				ViewBag.mensaje = 0;
			}
			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP");
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
			return View();
		}

		// POST: RegUser/Create
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
		// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegAl([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil")] usuario usuario, alumnos a, HttpPostedFileBase file)
		{

			if (file != null)
			{
				var filecarga = System.IO.Path.GetFileName(file.FileName);

				var extension = System.IO.Path.GetExtension(filecarga);

				if (extension == ".jpg")
				{

					//contrato.nombre = filecarga;
					usuario.Foto = new byte[file.ContentLength];
			
						try
						{
							
							usuario.idPerfil = 1;
							db.usuario.Add(usuario);
							db.SaveChanges();

							a.idUsuario = usuario.idUsuario;
							db.alumnos.Add(a);
							db.SaveChanges();
							return RedirectToAction("Index", "Home");

						//return RedirectToAction("Index", "Home", new { mensaje = 1 });
					}
					catch (Exception e)
						{
							System.Diagnostics.Debug.Write(e);
							System.Diagnostics.Debug.Write(" - Error al actualizar el registro");
						}
					}
					else
					{
						System.Diagnostics.Debug.Write("El archivo no es JPG");
					}
				}
				else
				{
					System.Diagnostics.Debug.Write("No se cargo ningun archivo");
				}


			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
			return View(usuario);
		}

		// GET: RegUser/Create
		public ActionResult RegMa(int? mesg)
		{

			ViewBag.mensaje = mesg;

			if (ViewBag.mensaje != null)
			{
				ViewBag.mensaje = 1;
			}
			else
			{
				ViewBag.mensaje = 0;
			}
			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP");
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
			return View();
		}

		// POST: RegUser/Create
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
		// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegMa([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil")] usuario usuario, maestros m, HttpPostedFileBase file)
		{

			if (file != null)
			{
				var filecarga = System.IO.Path.GetFileName(file.FileName);

				var extension = System.IO.Path.GetExtension(filecarga);

				if (extension == ".jpg")
				{

					//contrato.nombre = filecarga;
					usuario.Foto = new byte[file.ContentLength];

					try
					{

						usuario.idPerfil = 2;
						db.usuario.Add(usuario);
						db.SaveChanges();

						m.idUsuario = usuario.idUsuario;
						db.maestros.Add(m);
						db.SaveChanges();
						return RedirectToAction("Index", "Home");

						//return RedirectToAction("Index", "Home", new { mensaje = 1 });
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.Write(e);
						System.Diagnostics.Debug.Write(" - Error al actualizar el registro");
					}
				}
				else
				{
					System.Diagnostics.Debug.Write("El archivo no es JPG");
				}
			}
			else
			{
				System.Diagnostics.Debug.Write("No se cargo ningun archivo");
			}


			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
			return View(usuario);
		}

		// GET: RegUser/Create
		public ActionResult RegTP(int? mesg)
		{

			ViewBag.mensaje = mesg;

			if (ViewBag.mensaje != null)
			{
				ViewBag.mensaje = 1;
			}
			else
			{
				ViewBag.mensaje = 0;
			}
			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP");
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
			return View();
		}

		// POST: RegUser/Create
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
		// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegTP([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idPerfil")] usuario usuario, padretutor tp, HttpPostedFileBase file)
		{

			if (file != null)
			{
				var filecarga = System.IO.Path.GetFileName(file.FileName);

				var extension = System.IO.Path.GetExtension(filecarga);

				if (extension == ".jpg")
				{

					//contrato.nombre = filecarga;
					usuario.Foto = new byte[file.ContentLength];

					try
					{

						usuario.idPerfil = 3;
						db.usuario.Add(usuario);
						db.SaveChanges();

						tp.idUsuario = usuario.idUsuario;
						db.padretutor.Add(tp);
						db.SaveChanges();
						return RedirectToAction("Index", "Home");

						//return RedirectToAction("Index", "Home", new { mensaje = 1 });
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.Write(e);
						System.Diagnostics.Debug.Write(" - Error al actualizar el registro");
					}
				}
				else
				{
					System.Diagnostics.Debug.Write("El archivo no es JPG");
				}
			}
			else
			{
				System.Diagnostics.Debug.Write("No se cargo ningun archivo");
			}


			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
			return View(usuario);
		}

		// GET: RegUser/Create
		public ActionResult RegAd(int? mesg)
		{

			ViewBag.mensaje = mesg;

			if (ViewBag.mensaje != null)
			{
				ViewBag.mensaje = 1;
			}
			else
			{
				ViewBag.mensaje = 0;
			}
			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP");
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
			return View();
		}

		// POST: RegUser/Create
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
		// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegAd([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idPerfil")] usuario usuario, administrador ad, HttpPostedFileBase file)
		{

			if (file != null)
			{
				var filecarga = System.IO.Path.GetFileName(file.FileName);

				var extension = System.IO.Path.GetExtension(filecarga);

				if (extension == ".jpg")
				{

					//contrato.nombre = filecarga;
					usuario.Foto = new byte[file.ContentLength];

					try
					{

						usuario.idPerfil = 4;
						db.usuario.Add(usuario);
						db.SaveChanges();

						ad.idUsuario = usuario.idUsuario;
						db.administrador.Add(ad);
						db.SaveChanges();
						return RedirectToAction("Index", "Home");

						//return RedirectToAction("Index", "Home", new { mensaje = 1 });
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.Write(e);
						System.Diagnostics.Debug.Write(" - Error al actualizar el registro");
					}
				}
				else
				{
					System.Diagnostics.Debug.Write("El archivo no es JPG");
				}
			}
			else
			{
				System.Diagnostics.Debug.Write("No se cargo ningun archivo");
			}


			ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
			ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
			return View(usuario);
		}
		//// GET: RegUser/Create
		//public ActionResult Create()
		//{
		//	ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP");
		//	ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre");
		//	return View();
		//}

		//// POST: RegUser/Create
		//// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
		//// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil")] usuario usuario, alumnos a)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		db.usuario.Add(usuario);
		//		db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}

		//	ViewBag.idPerfil = new SelectList(db.perfil, "idPerfil", "NombreP", usuario.idPerfil);
		//	ViewBag.idSeccion = new SelectList(db.seccion, "idSeccion", "Nombre", usuario.idSeccion);
		//	return View(usuario);
		//}
	}
}
