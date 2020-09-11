using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CFPPE.Models;

namespace CFPPE.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		public plataformaEntities db;

		public UsuarioRepository()
		{
			this.db = new plataformaEntities();
		}

		public usuario GetPorUsuario(string usuario)
		{
			var query = (from u in db.usuario
						 where u.Nombre == usuario
						 select u);
			return query.FirstOrDefault<usuario>();
		}

		public usuario getPorCorreo(string correo)
		{
			var query = (from u in db.usuario
						 where u.Correo == correo
						 select u);
			return query.FirstOrDefault<usuario>();
		}

		public List<usuario> getPorNombre(string usuario)
		{
			List<usuario> listaUsuarios = new List<usuario>();
			var query = (from u in db.usuario
						 where u.Nombre.Contains(usuario)
						 select u);

			foreach (var obj in query)
			{
				listaUsuarios.Add(obj);
			}

			return listaUsuarios;
		}

		public List<perfil> obtenerPerfilSinProveedor()
		{
			List<perfil> listaUsuarios = new List<perfil>();
			var query = (from u in db.perfil
						 where u.idPerfil != 2
						 select u);

			foreach (var obj in query)
			{
				listaUsuarios.Add(obj);
			}

			return listaUsuarios;
		}

		public List<usuario> getPorPerfil(int idPerfil)
		{
			List<usuario> listUsuarios = new List<usuario>();
			var Query = (from u in db.usuario
						 where u.idPerfil == idPerfil
						 select u);

			foreach (var obj in Query)
			{
				listUsuarios.Add(obj);
			}

			return listUsuarios;
		}

		public usuario getPorUserCorreo(string usuario, string correo)
		{
			var query = (from u in db.usuario
						 where u.Nombre == usuario && u.Correo == correo
						 select u);
			return query.FirstOrDefault<usuario>();
		}

		usuario IUsuarioRepository.GetPorUsuario(string usuario)
		{
			throw new NotImplementedException();
		}

		usuario IUsuarioRepository.getPorCorreo(string correo)
		{
			throw new NotImplementedException();
		}

		List<usuario> IUsuarioRepository.getPorNombre(string usuario)
		{
			throw new NotImplementedException();
		}

		List<perfil> IUsuarioRepository.obtenerPerfilSinusuario()
		{
			throw new NotImplementedException();
		}

		List<usuario> IUsuarioRepository.getPorPerfil(int idPerfil)
		{
			throw new NotImplementedException();
		}

		usuario IUsuarioRepository.getPorUserCorreo(string Nombre, string Correo)
		{
			throw new NotImplementedException();
		}
	}
}