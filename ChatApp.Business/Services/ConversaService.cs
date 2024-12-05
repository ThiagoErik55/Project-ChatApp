using Microsoft.EntityFrameworkCore;
using ChatApp.Persistence;
using ChatApp.Model.Conversations;
using ChatApp.Model.Messages;

public class ConversaService
{
    private readonly ChatAppDbContext _context;

    public ConversaService(ChatAppDbContext context)
    {
        _context = context;
    }

    public Conversa CriarConversa(IEnumerable<int> usuarioIds)
    {
        var usuarios = _context.Usuarios.Where(u => usuarioIds.Contains(u.Id)).ToList();

        var conversa = new Conversa
        {
            Participantes = usuarios,
            Mensagens = new List<Mensagem>(),
            DataUltimaMensagem = DateTime.Now
        };

        _context.Conversas.Add(conversa);
        _context.SaveChanges();

        return conversa;
    }

    public IEnumerable<Conversa> ObterConversasUsuario(int usuarioId)
    {
        return _context.Conversas
            .Include(c => c.Participantes)
            .Include(c => c.Mensagens)
            .Where(c => c.Participantes.Any(u => u.Id == usuarioId))
            .ToList();
    }
}
