using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CFPPE.
//using CFPPE.lib;
using CFPPE.Models;
using CFPPE.Repositories;
namespace CBPPE.Controllers
{
	public class LogueoController : Controller
	{
		IUsuarioRepository _repoUsuarios;

		public LogueoController() : this(new UsuarioRepository())
		{

		}

		public LogueoController(IUsuarioRepository repository)
		{
			_repoUsuarios = repository;
		}

		public ActionResult Index(int error = 0, string mensaje = "")
		{
			//cambiar mensaje "Bienvenido a su sesion puede comenzar" 
			//y direccion despues que los homes esten listos 
			//tambien checar que redireccione a su home correspondiente ¿como hacerlo?
			if (SessionHelper.GetUser() != 0)
			{
				ViewBag.mensaje = "Bienvenido a su sesion puede comenzar";
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.error = error;
				ViewBag.mensaje = mensaje;
				return View();
			}
		}

		// POST: Para iniciar sesión
		[HttpPost]
		public ActionResult Index(FormCollection frm)
		{
			AESCryptoManejador mnjAes = new AESCryptoManejador();

			string usuario = frm["Correo"];
			string pass = frm["Contraseña"];
			//Verificar si el usuario existe
			usuario objUsuario = _repoUsuarios.getPorCorreo(usuario);
			if (objUsuario == null)
			{
				return RedirectToAction("Index", "Logueo", new { error = 1, mensaje = "El usuario no existe" });
			}
			if (mnjAes.descifrar(objUsuario.Contraseña) != pass)
			{
				return RedirectToAction("Index", "Logueo", new { error = 1, mensaje = "La contraseña es incorrecta" });
			}
			//if (objUsuario.Status != 1)
			//{
			//	return RedirectToAction("Index", "Logueo", new { error = 1, mensaje = "Usuario bloqueado" });
			//}

			//Para agregar el usuario a la sesión
			SessionHelper.AddUserToSession(objUsuario);

			return RedirectToAction("Index", "Home", new { error = 1, mensaje = "Por el momento no hay Home / se notificara cuando  este listo" });
		}

		public ActionResult Salir()
		{
			SessionHelper.DestroyUserSession();
			return RedirectToAction("Index", "Home");
		}
	}
}