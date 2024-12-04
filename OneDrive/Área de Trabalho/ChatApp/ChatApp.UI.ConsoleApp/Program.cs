using Microsoft.EntityFrameworkCore;
using ChatApp.Persistence.Context;

namespace ChatApp.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatAppDbContext>();
            optionsBuilder.UseSqlite("Data Source=chatapp.db");

            using (var context = new ChatAppDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                Console.WriteLine("Banco de dados criado ou verificado!");
            }
        }
    }
}
