using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CFPPE.Models;
using CFPPE.lib;
using CFPPE.Repositories;

namespace CFPPE.Controllers
{
    public class RegUserController : Controller
    {
        private plataformaEntities db = new plataformaEntities();

		IUsuarioRepository _repoUsuarios;

		public RegUserController() : this(new UsuarioRepository())
		{

		}

		public RegUserController(IUsuarioRepository repository)
		{
			_repoUsuarios = repository;
		}
		AESCryptoManejador mnjAES = new AESCryptoManejador();

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
		public ActionResult RegAl([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil,TokenRecovery")] usuario usuario, alumnos a, HttpPostedFileBase file)
		{

			if (file != null)
			{
				var filecarga = System.IO.Path.GetFileName(file.FileName);

				var extension = System.IO.Path.GetExtension(filecarga);

				if (extension == ".jpg")
				{

					//contrato.nombre = filecarga;
					usuario.Foto = new byte[file.ContentLength];
                    file.InputStream.Read(usuario.Foto, 0, file.ContentLength);
                    System.Diagnostics.Debug.Write("Extensión..." + extension);
                    try
						{
							
							usuario.idPerfil = 1;
                        usuario.TokenRecovery = "";
							db.usuario.Add(usuario);
							db.SaveChanges();

							a.idUsuario = usuario.idUsuario;
							db.alumnos.Add(a);
							db.SaveChanges();
							//return RedirectToAction("Index", "Home");

						return RedirectToAction("Index", "Home", new { mensaje = 1 });
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
		public ActionResult RegMa([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idSeccion,idPerfil,TokenRecovery")] usuario usuario, maestros m, HttpPostedFileBase file)
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
                        usuario.TokenRecovery = "";
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
		public ActionResult RegTP([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idPerfil,tokenRecovery")] usuario usuario, padretutor tp, HttpPostedFileBase file)
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
                        usuario.TokenRecovery = "";
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
		public ActionResult RegAd([Bind(Include = "idUsuario,Foto,Nombre,APP,APM,Sexo,Direccion,Correo,Contraseña,Telefono,idPerfil,tokenRecovery")] usuario usuario, administrador ad, HttpPostedFileBase file)
		{

			if (file != null)
			{
				var filecarga = System.IO.Path.GetFileName(file.FileName);

				var extension = System.IO.Path.GetExtension(filecarga);

				if (extension == ".jpg")
				{
					
					usuario.Foto = new byte[file.ContentLength];

					try
					{

						usuario.idPerfil = 4;
                        usuario.TokenRecovery = "";
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


		//Para recuperar la contraseña
		public ActionResult Contraseña()
		{
			if (SessionHelper.GetUser() != 0)
			{
				return RedirectToAction("Index", "Home");
			}

			ViewBag.inicioSesion = 0;
			//List<CatClasifProv> listarCliasficacion = db.CatClasifProvSet.ToList();
			//ViewBag.listarClasificacion = listarCliasficacion;

			return View();
		}

		[HttpPost]
		public ActionResult Contraseña(FormCollection frm)
		{
			string usuario = frm["usuario"];
			string correo = frm["correo"];
			System.Diagnostics.Debug.WriteLine("Si llega al controlador" + frm["usuario"]);
			System.Diagnostics.Debug.WriteLine("Si llega al controlador" + frm["correo"]);

			//if (usuario.Equals(usuario1))
			//{
			usuario userRecupera = _repoUsuarios.getPorUserCorreo(usuario, correo);
			if (userRecupera == null)
			{
				ViewBag.error = 1;
				ViewBag.mensaje = "El correo o el usuario no existe";
				return View();
				//return RedirectToAction("Contraseña", "Registro", new { error = 1, mensaje = "El correo no existe" });
			}
			////else if (userRecupera.status != 1)
			////{
			////	ViewBag.error = 1;
			////	ViewBag.mensaje = "Usuario bloqueado, no puedes cambiar la contraseña";
			////	return View();
			////	//return RedirectToAction("Contraseña", "Registro", new { error = 1, mensaje = "Usuario bloqueado, no puedes cambiar la contraseña" });
			////}
			////else
			////{
			////	enviarCorreoContraseña(userRecupera.Correo, userRecupera.idUsuario);
			////	//return RedirectToAction("Recupera/"+userRecupera.idusuario, "Registro");
			////	return RedirectToAction("Index", "Home");
			////}
			//} else
			//{
			//    ViewBag.error = 1;
			//     ViewBag.mensaje = "Los usuarios no son iguales";
			//}
			return View();
		}


		public ActionResult Recupera(int? id)
		{
			if (SessionHelper.GetUser() != 0)
			{
				return RedirectToAction("Index", "Home");
			}
			System.Diagnostics.Debug.WriteLine("Si llega al controlador" + id);
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			usuario usuarios = db.usuario.Find(id);
			if (usuarios == null)
			{
				return HttpNotFound();
			}

			//usuarios.Contraseña = mnjAES.descifrar(usuarios.Contraseña);

			return View();
		}

		// GET: CatAreas/Details/5
		[HttpPost]
		public ActionResult Recupera(FormCollection frm, int? id)
		{
			System.Diagnostics.Debug.WriteLine("Pass" + frm["pass"]);
			System.Diagnostics.Debug.WriteLine("Pass1" + frm["pass1"]);
			System.Diagnostics.Debug.WriteLine("id" + frm["idusuario"]);
			if (frm["pass"] != frm["pass1"])
			{
				ViewBag.error = 1;
				ViewBag.mensaje = "Las contraseñas no son iguales";
				return View();
			}
			else
			{
				usuario usuarios = db.usuario.Find(id);
				//Para log
				//int log = _logReppository.GuardaLog(usuarios.idusuario, "Home/Index");

				System.Diagnostics.Debug.WriteLine("Pass" + mnjAES.cifrar(frm["pass"]));
				//usuarios.Contraseña = mnjAES.cifrar(frm["pass"]);
				db.Entry(usuarios).State = EntityState.Modified;
				db.SaveChanges();

				return RedirectToAction("Index", "Home");
			}
		}

		////public int numeroRandom()
		////{
		////	Random rnd = new Random();
		////	int numero = rnd.Next(1000, 99999);

		////	return numero;
		////}

		////public int preparaCorreo(string numProv, Proveedores prov)
		////{
		////	//string qrImage = QRCode(prov.nombrefiscal, numProv, prov.rfc);
		////	string logoImage = "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";

		////	//Enviar al repositorio el Proveedor y los bases 64
		////	int resultado = _correosRepository.Correo(prov, /*qrImage,*/logoImage, 1);

		////	return resultado;
		////}

		////public void enviarCorreoContraseña(string correo, int id)
		////{
		////	//Creando el objeto
		////	MailMessage email = new MailMessage();
		////	email.To.Add(new MailAddress(correo));
		////	email.From = new MailAddress("bocar.proveedores@bocar.com");
		////	email.Subject = "Recuperar contraseña del portal proveedores ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
		////	string body = "Para poder recuperar tu contraseña accede al siguiente link. <br /> http://bocarproveedores.dyndns.org/Registro/Recupera/" + id;
		////	email.IsBodyHtml = true;
		////	email.Body = "<table width='100%'><tr><td align='right'>" +
		////		"<img src='http://bocarproveedores.dyndns.org/Imagenes/logo-01.png' alt='' width='93px' height='23px'/>" +
		////		"</td>" +
		////		"</tr>" +
		////		"</table><br />" +
		////	"<div style='font-family:Arial'; font-size: '12px;'>" + body + "</div>" + "<br />GRUPO BOCAR <br /> <hr style='border: 1px solid #0033A0; height: 1px; background-color: #0033A0;'/>";
		////	email.Priority = MailPriority.Normal;

		////	//Definir objeto smtpclient
		////	SmtpClient smtp = new SmtpClient();
		////	smtp.Host = "smtp.office365.com";
		////	smtp.Port = 587;
		////	smtp.EnableSsl = true;
		////	smtp.UseDefaultCredentials = false;
		////	smtp.Credentials = new NetworkCredential("bocar.proveedores@bocar.com", "Bocar4000");

		////	string output = null;

		////	//Enviar correo electronico 
		////	try
		////	{
		////		smtp.Send(email);
		////		email.Dispose();
		////		output = "Corre electrónico fue enviado satisfactoriamente.";
		////	}
		////	catch (Exception ex)
		////	{
		////		output = "Error enviando correo electrónico: " + ex.Message;
		////	}

		////	Console.WriteLine(output);

		////	////Definir objeto smtpclient
		////	//SmtpClient smtp = new SmtpClient();
		////	//smtp.Host = "SMTP.office365.com";
		////	//smtp.Port = 587;
		////	//smtp.EnableSsl = true;
		////	//smtp.UseDefaultCredentials = false;
		////	//smtp.Credentials = new System.Net.NetworkCredential("suppliers@bocar.com", "", "bocar.com");


		////	//string output = null;

		////	////Enviar correo electronico 
		////	//try
		////	//{
		////	//    smtp.Send(email);
		////	//    email.Dispose();
		////	//    output = "Corre electrónico fue enviado satisfactoriamente.";
		////	//}
		////	//catch (Exception ex)
		////	//{
		////	//    output = "Error enviando correo electrónico: " + ex.Message;
		////	//    System.Diagnostics.Debug.Write("Error" + ex);
		////	//}

		////	//Console.WriteLine(output);

		////}
		///

	
		public ActionResult RegADM()
		{
			
			return View();
		}

		// POST: RegUser/Create
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
		// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult RegADM(FormCollection frm)
		{
			string clave = frm["clave"];
			//var chec = 
			if (clave == "TJK2508736")
			{
				return RedirectToAction("RegAd", "RegUser");
			}

		
			return View();
		}
	}
}
