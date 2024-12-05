using Microsoft.EntityFrameworkCore;
using ChatApp.Persistence;

var options = new DbContextOptionsBuilder<ChatAppDbContext>()
    .UseSqlite("Data Source=chatapp.db")
    .Options;

using var context = new ChatAppDbContext(options);
context.Database.EnsureCreated();

Console.WriteLine("Banco de dados criado com sucesso!");

