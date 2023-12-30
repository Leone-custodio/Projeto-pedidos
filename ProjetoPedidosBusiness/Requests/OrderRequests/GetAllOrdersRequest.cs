using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class GetAllOrdersRequest : IRequest<OrderCommandResult>
    {
        public OrderCommandResult? Result{ get; set; }
    }
}
