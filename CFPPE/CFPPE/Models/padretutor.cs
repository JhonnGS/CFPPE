//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CFPPE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class padretutor
    {
        public long idPadre { get; set; }
        public string Nombre { get; set; }
        public string APP { get; set; }
        public string APM { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public long idUsuario { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
