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
    
    public partial class calificacion
    {
        public long idCalificacion { get; set; }
        public long idMateria { get; set; }
        public long idAlumno { get; set; }
        public string Calificacion1 { get; set; }
    
        public virtual alumnos alumnos { get; set; }
        public virtual materia materia { get; set; }
    }
}
