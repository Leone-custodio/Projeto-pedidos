using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class UpdatePasswordRequest : IRequest<UserCommandResult>
    {
        public string? Cpf { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
    }
}
