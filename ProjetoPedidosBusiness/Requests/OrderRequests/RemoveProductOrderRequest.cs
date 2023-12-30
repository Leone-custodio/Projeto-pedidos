using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class RemoveProductOrderRequest : IRequest<OrderCommandResult>
    {
        public string Id { get; set; } = "";
        public string Product { get; set; } = "";
    }
}
