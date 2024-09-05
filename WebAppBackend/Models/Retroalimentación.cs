using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Retroalimentación
    {
        public int Id { get; set; }
        public int? Instructor { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }
        public string? Contenido { get; set; }

        public virtual Curso? CursoNavigation { get; set; }
        public virtual Estudiante? EstudianteNavigation { get; set; }
        public virtual Instructor? InstructorNavigation { get; set; }
    }
}
