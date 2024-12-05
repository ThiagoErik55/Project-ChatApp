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
}
