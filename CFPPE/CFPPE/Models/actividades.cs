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
    
    public partial class actividades
    {
        public long idActividad { get; set; }
        public long idAlumno { get; set; }
        public long idMateria { get; set; }
        public string NombreA { get; set; }
        public string Tema { get; set; }
        public int Calificacion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public string Detalle { get; set; }
        public System.TimeSpan TempoActividad { get; set; }
        public int ValorA { get; set; }
        public long idMaestro { get; set; }
    
        public virtual alumnos alumnos { get; set; }
        public virtual maestros maestros { get; set; }
        public virtual materia materia { get; set; }
    }
}
