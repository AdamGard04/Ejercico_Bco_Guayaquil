using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Certificado
    {
        public int Id { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }
        public DateTime? FechaExpedicion { get; set; }

        public virtual Curso? CursoNavigation { get; set; }
        public virtual Estudiante? EstudianteNavigation { get; set; }
    }
}
