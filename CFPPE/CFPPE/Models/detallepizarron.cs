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
    
    public partial class detallepizarron
    {
        public int idDetallePizarron { get; set; }
        public int idAP { get; set; }
        public byte[] Documento { get; set; }
        public string Link { get; set; }
    
        public virtual archivospizarronma archivospizarronma { get; set; }
    }
}