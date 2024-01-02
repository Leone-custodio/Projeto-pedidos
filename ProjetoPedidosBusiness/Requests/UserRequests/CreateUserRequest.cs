using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class CreateUserRequest : IRequest<UserCommandResult>
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string CPF { get; set; } = "";
        public string Address { get; set; } = "";
        public string Password { get; set; } = "";
    }
}