﻿namespace ProjetoPedidosDomain.Models
{
    public class User : Identity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
    }
}
