using System;
using System.Collections.Generic;

namespace WebAppBackend.Models
{
    public partial class Preguntum
    {
        public int Id { get; set; }
        public string? Enunciado { get; set; }
        public string? Opciones { get; set; }
        public string? RespuestaCorrecta { get; set; }
    }
}
