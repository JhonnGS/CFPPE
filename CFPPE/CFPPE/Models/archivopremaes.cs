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
    
    public partial class archivopremaes
    {
        public long idArchivoPM { get; set; }
        public long idMaestro { get; set; }
        public string Nombre { get; set; }
        public bool Archivo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Descricion { get; set; }
    
        public virtual maestros maestros { get; set; }
    }
}
