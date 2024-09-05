using Microsoft.EntityFrameworkCore;
using WebAppBackend.Dto;
using WebAppBackend.Models;

namespace WebAppBackend.Services
{
    public class UsuarioServices
    {
        private readonly CursosBDContext _context;

        public UsuarioServices(CursosBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDto>> getUsuarios()
        {
            return await _context.Usuarios.Select(u => new UsuarioDto
            {
                Nombre = u.Nombre,
                Email = u.Email,
                Rol = u.Rol,
                Clave = u.Clave,
            }).ToListAsync();
        }

        public async Task<UsuarioDto?> getUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = usuario.Rol,
                Clave = usuario.Clave
            };
        }

        public async Task<UsuarioDto> addUsuario(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario()
            {
                Nombre = usuarioDto.Nombre,
                Email = usuarioDto.Email,
                Rol = usuarioDto.Rol,
                Clave = usuarioDto.Clave
            };
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuarioDto;
        }

        public async Task<bool> updateUsuario(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            usuario.Nombre = usuarioDto.Nombre;
            usuario.Email = usuarioDto.Email;
            usuario.Rol = usuarioDto.Rol;
            usuario.Clave = usuarioDto.Clave;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
