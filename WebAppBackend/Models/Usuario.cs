using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Notificacións = new HashSet<Notificación>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Rol { get; set; }
        public string Clave { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }

        public virtual Estudiante? Estudiante { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public virtual ICollection<Notificación> Notificacións { get; set; }
    }
}
