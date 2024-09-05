using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Cuestionario
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Preguntas { get; set; }
        public DateTime? FechaLimite { get; set; }
        public int? IntentosPermitidos { get; set; }
    }
}
