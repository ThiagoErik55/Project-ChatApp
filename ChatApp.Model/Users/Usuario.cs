﻿using ChatApp.Model.Enums;

namespace ChatApp.Model.Users
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public StatusUsuario Status { get; set; } = StatusUsuario.Offline;
    }
}