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
    
    public partial class tareas
    {
        public long idTarea { get; set; }
        public long idAlumno { get; set; }
        public long idMateria { get; set; }
        public long idMaestro { get; set; }
        public string NombreT { get; set; }
        public string Tema { get; set; }
        public int CalificacionA { get; set; }
        public int CalificacionR { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime Fecha_E { get; set; }
        public string Detalle { get; set; }
        public byte[] Archivo { get; set; }
    
        public virtual alumnos alumnos { get; set; }
        public virtual maestros maestros { get; set; }
        public virtual materia materia { get; set; }
    }
}
