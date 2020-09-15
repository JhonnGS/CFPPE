using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CFPPE.Models;

namespace CFPPE.Repositories
{
	public interface ILogRepository
	{
		int GuardaLog(int usuario, string pantalla);

		/// <summary>
		/// Busqueda a BD por fecha inicial, fecha final y por usuario en Log
		/// </summary>
		/// <param name="f1"></param>
		/// <param name="f2"></param>
		/// <returns>Lista de consulta con criterios en Accesos</returns>

		List<usuario> getAccesoCriterio(string f1, string f2, int usuario);
	}
}