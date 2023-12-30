using MediatR;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class GetAllUsersRequest : IRequest<UserCommandResult>
    {
        public List<User>? ListUsers { get; set; }
    }
}
