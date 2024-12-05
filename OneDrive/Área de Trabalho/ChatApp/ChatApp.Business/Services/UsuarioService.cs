using ChatApp.Persistence;
using ChatApp.Model.Enums;
using ChatApp.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Business.Services { 
    public class UsuarioService
    {
        private readonly ChatAppDbContext _context;

        public UsuarioService(ChatAppDbContext context)
        {
            _context = context;
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null && usuario.SenhaHash == senha)
            {
                return usuario;
            }

            return null;
        }

        public Usuario CriarUsuario(string nome, string email, string senha)
        {
            var novoUsuario = new Usuario
            {
                Nome = nome,
                Email = email,
                SenhaHash = senha,
                Status = StatusUsuario.Offline
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            return novoUsuario;
        }

        public void AtualizarStatus(int usuarioId, StatusUsuario status)
        {
            var usuario = _context.Usuarios.Find(usuarioId);

            if (usuario != null)
            {
                usuario.Status = status;
                _context.SaveChanges();
            }
        }
    }
}