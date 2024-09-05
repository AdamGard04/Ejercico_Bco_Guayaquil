using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Certificados = new HashSet<Certificado>();
            Inscripcións = new HashSet<Inscripción>();
            Retroalimentacións = new HashSet<Retroalimentación>();
        }

        public int Id { get; set; }
        public string? CursosInscritos { get; set; }
        public string? Progreso { get; set; }
        public string? CertificadosObtenidos { get; set; }

        public virtual Usuario IdNavigation { get; set; } = null!;
        public virtual ICollection<Certificado> Certificados { get; set; }
        public virtual ICollection<Inscripción> Inscripcións { get; set; }
        public virtual ICollection<Retroalimentación> Retroalimentacións { get; set; }
    }
}
