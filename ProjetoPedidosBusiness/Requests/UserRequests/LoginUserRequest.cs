using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class LoginUserRequest : IRequest<UserCommandResult>
    {
        public string? Cpf { get; set; }
        public string? Password { get; set; }
    }
}
