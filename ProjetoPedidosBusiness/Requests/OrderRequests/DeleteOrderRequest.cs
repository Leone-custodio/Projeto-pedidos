using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class DeleteOrderRequest : IRequest<OrderCommandResult>
    {
        public string Id { get; set; } = "";
    }
}
