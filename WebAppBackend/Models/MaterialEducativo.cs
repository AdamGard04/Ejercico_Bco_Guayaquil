using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class MaterialEducativo
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Url { get; set; }
        public DateTime? FechaSubida { get; set; }
    }
}
