using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Retroalimentacións = new HashSet<Retroalimentación>();
        }

        public int Id { get; set; }
        public string? Especialidad { get; set; }
        public string? CursosCreados { get; set; }

        public virtual Usuario IdNavigation { get; set; } = null!;
        public virtual ICollection<Retroalimentación> Retroalimentacións { get; set; }
    }
}
