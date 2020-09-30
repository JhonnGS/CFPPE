using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CFPPE.Models;
//using static CFPPE.lib.AutenticadoAtribute;
using CFPPE.Repositories;

namespace CFPPE.Repositories
{
	public class LogRepository /*: ILogRepository*/
	{
		private plataformaEntities db = new plataformaEntities();

		public int GuardaLog(int usuario, string pantalla)
		{
			//DateTime fecha = DateTime.Now;
			usuario nuevo = new usuario();
			nuevo.idUsuario = usuario;
			//nuevo.ingreso = fecha;
			//nuevo.pantalla = pantalla;

			db.usuario.Add(nuevo);
			db.SaveChanges();
			return 1;

		}


		//public List<Log> getAccesoCriterio(string f1, string f2, int usuario)
		//{
		//	List<Log> consultaFecha = new List<Log>();
		//	if (f1 != "" && f2 != "" && usuario == 0)
		//	{
		//		DateTime date_i = Convert.ToDateTime(f1);
		//		DateTime date_f = Convert.ToDateTime(f2);

		//		string format = date_i.ToString("MM/dd/yyyy").Replace("-", "/");
		//		string format2 = date_f.ToString("MM/dd/yyyy").Replace("-", "/");

		//		string fechaI = format + " 00:00:00" + " am";
		//		string fechaF = format2 + " 11:59:59" + " pm";

		//		var fi = System.DateTime.ParseExact(fechaI, "MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
		//		var ff = System.DateTime.ParseExact(fechaF, "MM/dd/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
		//		var query = (from p in db.LogSet
		//					 where p.ingreso >= fi && p.ingreso <= ff
		//					 select p);
		//		foreach (var obj in query)
		//		{
		//			consultaFecha.Add(obj);
		//		}
		//	}
		//	else
		//	if (usuario != 0 && f1 == "" && f2 == "")
		//	{
		//		var query2 = (from p in db.LogSet
		//					  where p.idusuario == usuario
		//					  select p);
		//		foreach (var obj in query2)
		//		{
		//			consultaFecha.Add(obj);
		//		}
		//	}
		//	if (f1 != "" && f2 != "" && usuario != 0)
		//	{
		//		DateTime date_i = Convert.ToDateTime(f1);
		//		DateTime date_f = Convert.ToDateTime(f2);

		//		string format = date_i.ToString("MM/dd/yyyy").Replace("-", "/");
		//		string format2 = date_f.ToString("MM/dd/yyyy").Replace("-", "/");

		//		string fechaI = format + " 00:00:00" + " am";
		//		string fechaF = format2 + " 11:59:59" + " pm";

		//		var fi = System.DateTime.ParseExact(fechaI, "MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
		//		var ff = System.DateTime.ParseExact(fechaF, "MM/dd/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

		//		var query3 = (from p in db.LogSet
		//					  where p.ingreso >= fi && p.ingreso <= ff && p.idusuario == usuario
		//					  select p);
		//		foreach (var obj in query3)
		//		{
		//			consultaFecha.Add(obj);
		//		}
		//	}
		//	return consultaFecha;
		//}
	}
}