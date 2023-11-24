﻿namespace ProjetoPedidosBusiness.Commands.Responses
{
    public class CreateUserResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
    }
}