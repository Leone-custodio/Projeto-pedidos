﻿namespace ProjetoPedidosBusiness.Commands.Requests
{
    public class CreateUserRequest 
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
    }
}