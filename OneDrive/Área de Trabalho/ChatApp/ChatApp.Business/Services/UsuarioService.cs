namespace ChatApp.Business.Services
{
    public class UsuarioService
    {
        private readonly ChatAppDbContext _context;

        public UsuarioService(ChatAppDbContext context)
        {
            _context = context;
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.SenhaHash == senha);
        }

        // Outros métodos de serviço para gerenciar usuários
    }
}
