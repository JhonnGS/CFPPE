using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using CFPPE.Models;

namespace CBPPE.lib
{
	public class SessionHelper
	{
		public static bool ExistUserInSession()
		{
			if (HttpContext.Current.Session["ref"] != null & Convert.ToInt32(HttpContext.Current.Session["ref"]) > 0)
				return true;
			else
				return false;
		}
		public static void DestroyUserSession()
		{
			FormsAuthentication.SignOut();
			HttpContext.Current.Session.Clear();
			HttpContext.Current.Session.Abandon();
		}
		public static int GetUser()
		{
			return Convert.ToInt32(HttpContext.Current.Session["ref"]);
		}
		public static void AddUserToSession(usuario objUsu)
		{
			HttpContext.Current.Session["ref"] = objUsu.idUsuario;
			HttpContext.Current.Session["Foto"] = objUsu.Foto;
			HttpContext.Current.Session["Nombre"] = objUsu.Nombre;
			HttpContext.Current.Session["APP"] = objUsu.APP;
			HttpContext.Current.Session["APM"] = objUsu.APM;
			HttpContext.Current.Session["Correo"] = objUsu.Correo;
			HttpContext.Current.Session["Contraseña"] = objUsu.Contraseña;
			HttpContext.Current.Session["Sexo"] = objUsu.Sexo;
			HttpContext.Current.Session["Telefono"] = objUsu.Telefono;
			HttpContext.Current.Session["Direccion"] = objUsu.Direccion;
			HttpContext.Current.Session["idSeccion"] = objUsu.idSeccion;
			HttpContext.Current.Session["idPerfil"] = objUsu.idPerfil;
			HttpContext.Current.Session["perfDescripcion"] = objUsu.perfil.NombreP;
			//Por el momento en lo que se terminan los permisos
			if (objUsu.idPerfil == 1)
			{
				HttpContext.Current.Session["idPerfil"] = objUsu.idPerfil;
				//HttpContext.Current.Session["extranjero"] = objUsu.alumnos.ElementAtOrDefault(0).usuario;
			}
			if (objUsu.idPerfil == 2)
			{
				HttpContext.Current.Session["perfil"] = objUsu.idPerfil;
				//HttpContext.Current.Session["extranjero"] = objUsu.Plataforma.ElementAtOrDefault(0).extranjero;
			}
			if (objUsu.idPerfil == 3)
			{
				HttpContext.Current.Session["perfil"] = objUsu.idPerfil;
				//HttpContext.Current.Session["extranjero"] = objUsu.Plataforma.ElementAtOrDefault(0).extranjero;
			}
			if (objUsu.idPerfil == 4)
			{
				HttpContext.Current.Session["perfil"] = objUsu.idPerfil;
				//HttpContext.Current.Session["extranjero"] = objUsu.Plataforma.ElementAtOrDefault(0).extranjero;
			}
		}
	}
}