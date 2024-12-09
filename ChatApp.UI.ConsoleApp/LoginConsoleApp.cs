using ChatApp.Persistence;
using Microsoft.EntityFrameworkCore;
using ChatApp.Business.Services;
using System;

namespace ChatApp.UI.ConsoleApp
{
    class LoginConsoleApp
    {
        private readonly UsuarioService _usuarioService;

        public LoginConsoleApp()
        {
            var options = new DbContextOptionsBuilder<ChatAppDbContext>()
                .UseSqlite("Data Source=chatapp.db")
                .Options;

            var context = new ChatAppDbContext(options);

            _usuarioService = new UsuarioService(context);
        }

        public void ExibirTelaDeLogin()
        {
            Console.WriteLine("Bem-vindo ao ChatApp!");
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            var usuario = _usuarioService.AutenticarUsuario(email, senha);

            if (usuario != null)
            {
                Console.WriteLine($"Bem-vindo, {usuario.Nome}!");
            }
            else
            {
                Console.WriteLine("Usu�rio ou senha inv�lidos. Tente novamente.");
            }
        }
    }
}
