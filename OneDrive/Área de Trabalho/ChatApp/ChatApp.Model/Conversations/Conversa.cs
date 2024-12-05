using System;
using System.Collections.Generic;
using ChatApp.Model.Users;
using ChatApp.Model.Messages;

namespace ChatApp.Model.Conversations
{
    public class Conversa
    {
        public int Id { get; set; }
        public ICollection<Usuario> Participantes { get; set; }
        public ICollection<Mensagem> Mensagens { get; set; }
        public DateTime DataUltimaMensagem { get; set; }
    }
}
