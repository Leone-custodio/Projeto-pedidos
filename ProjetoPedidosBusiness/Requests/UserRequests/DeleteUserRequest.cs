using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class DeleteUserRequest : IRequest<UserCommandResult>
    {
        public string Id { get; set; } = "";
    }
}
