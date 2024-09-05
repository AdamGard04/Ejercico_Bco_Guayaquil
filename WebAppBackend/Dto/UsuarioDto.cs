namespace WebAppBackend.Dto
{
    public class UsuarioDto
    {
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Rol { get; set; }
        public string Clave { get; set; } = null!;
    }
}
