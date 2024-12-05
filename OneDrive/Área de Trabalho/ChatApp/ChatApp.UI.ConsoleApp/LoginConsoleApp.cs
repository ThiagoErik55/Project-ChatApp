using ChatApp.Business.Services;
using ChatApp.Model.Users;
using System;

namespace ChatApp.UI.ConsoleApp
{
    class LoginConsoleApp
    {
        private readonly UsuarioService _usuarioService;

        public LoginConsoleApp()
        {
            _usuarioService = new UsuarioService(); 
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
                Console.WriteLine("Usuário ou senha inválidos. Tente novamente.");
            }
        }
    }
}
