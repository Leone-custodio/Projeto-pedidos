using MediatR;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class GetAllOrdersRequest : IRequest<object>
    {
        public List<Order> Orders { get; set; } = new();
    }
}
