using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFPPE.Models;

namespace CFPPE.Repositories
{
	public interface IUsuarioRepository
	{
		/// <summary>
		/// Busca por nombre de usuario y retorna un objeto de tipo Usuario
		/// </summary>
		/// <param name="usuario">nombre de usuario</param>
		/// <returns>Objeto usuario</returns>
		usuario GetPorUsuario(string usuario);
		/// <summary>
		/// Busca por correo para poder actualizar su correo
		/// </summary>
		/// <param name="correo">correo</param>
		/// <returns>Objeto usuario</returns>
		usuario getPorCorreo(string correo);
		/// <summary>
		/// Buscar por nombre usuario - filtro en Index
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns></returns>
		List<usuario> getPorNombre(string usuario);

		List<perfil> obtenerPerfilSinusuario();

		/// <summary>
		/// Lista por tipo perfil
		/// </summary>
		/// <param name="idPerfil"></param>
		/// <returns>Lista de usuarios</returns>
		List<usuario> getPorPerfil(int idPerfil);

		/// <summary>
		/// Verificar si existe usuario y correo de la bd
		/// </summary>
		/// <param name="Nombre"></param>
		/// <param name="Correo"></param>
		/// <returns></returns>
		usuario getPorUserCorreo(string Nombre, string Correo);

	}
}