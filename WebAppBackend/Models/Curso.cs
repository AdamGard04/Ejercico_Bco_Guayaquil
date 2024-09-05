using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Certificados = new HashSet<Certificado>();
            Inscripcións = new HashSet<Inscripción>();
            Retroalimentacións = new HashSet<Retroalimentación>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripción { get; set; }
        public int? Duración { get; set; }
        public string? Cronograma { get; set; }
        public string? Materiales { get; set; }
        public string? Instrucciones { get; set; }
        public string? Cuestionarios { get; set; }
        public string? Calificaciones { get; set; }

        public virtual ICollection<Certificado> Certificados { get; set; }
        public virtual ICollection<Inscripción> Inscripcións { get; set; }
        public virtual ICollection<Retroalimentación> Retroalimentacións { get; set; }
    }
}
