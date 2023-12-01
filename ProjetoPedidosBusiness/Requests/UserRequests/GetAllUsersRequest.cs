using MediatR;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class GetAllUsersRequest : IRequest<object>
    {
        public List<User>? ListUsers { get; set; }
    }
}
