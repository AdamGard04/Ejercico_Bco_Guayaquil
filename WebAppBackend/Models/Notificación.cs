using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Notificación
    {
        public int Id { get; set; }
        public int? Usuario { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string? Tipo { get; set; }

        public virtual Usuario? UsuarioNavigation { get; set; }
    }
}
