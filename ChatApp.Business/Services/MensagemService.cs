using Microsoft.EntityFrameworkCore;
using ChatApp.Model.Messages;
using ChatApp.Persistence;
using ChatApp.Model.Users;

public class MensagemService
{
    private readonly ChatAppDbContext _context;

    public MensagemService(ChatAppDbContext context)
    {
        _context = context;
    }

    public void EnviarMensagem(int conversaId, string conteudo, int remetenteId)
    {
        var mensagem = new Mensagem
        {
            Conteudo = conteudo,
            DataEnvio = DateTime.Now,
            Remetente = _context.Usuarios.Find(remetenteId),
            Visualizada = false
        };

        var conversa = _context.Conversas.Include(c => c.Mensagens).FirstOrDefault(c => c.Id == conversaId);
        if (conversa != null)
        {
            conversa.Mensagens.Add(mensagem);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Mensagem> ObterMensagensNaoLidas(int usuarioId)
    {
        return _context.Mensagens.Where(m => m.Visualizada == false && m.Remetente.Id != usuarioId).ToList();
    }

    public void MarcarMensagemComoVisualizada(int mensagemId)
    {
        var mensagem = _context.Mensagens.Find(mensagemId);

        if (mensagem != null)
        {
            mensagem.Visualizada = true;
            _context.SaveChanges();
        }
    }
}
