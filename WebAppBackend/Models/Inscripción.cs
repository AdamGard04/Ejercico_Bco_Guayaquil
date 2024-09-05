using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Inscripción
    {
        public int Id { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public decimal? Progreso { get; set; }
        public decimal? CalificacionFinal { get; set; }

        public virtual Curso? CursoNavigation { get; set; }
        public virtual Estudiante? EstudianteNavigation { get; set; }
    }
}
