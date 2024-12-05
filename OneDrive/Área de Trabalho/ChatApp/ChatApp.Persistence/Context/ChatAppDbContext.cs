using Microsoft.EntityFrameworkCore;
using ChatApp.Model.Users;
using ChatApp.Model.Messages;
using ChatApp.Model.Conversations;

namespace ChatApp.Persistence
{
    public class ChatAppDbContext : DbContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Conversa> Conversas { get; set; }
    }
}
