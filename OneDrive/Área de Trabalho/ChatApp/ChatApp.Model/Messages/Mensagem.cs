using ChatApp.Model.Users;

namespace ChatApp.Model.Messages
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public Usuario Remetente { get; set; }
        public bool Visualizada { get; set; }
        public int? RespostaId { get; set; }
    }
}
