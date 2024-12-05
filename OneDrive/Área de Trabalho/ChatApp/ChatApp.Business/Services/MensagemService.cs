public class MensagemService
{
    private readonly ChatAppDbContext _context;

    public MensagemService(ChatAppDbContext context)
    {
        _context = context;
    }

    public void EnviarMensagem(int conversaId, string conteudo, Usuario remetente)
    {
        var mensagem = new Mensagem
        {
            Conteudo = conteudo,
            DataEnvio = DateTime.Now,
            Remetente = remetente,
            Visualizada = false
        };

        var conversa = _context.Conversas.Include(c => c.Mensagens).FirstOrDefault(c => c.Id == conversaId);
        if (conversa != null)
        {
            conversa.Mensagens.Add(mensagem);
            _context.SaveChanges();
        }
    }
}
