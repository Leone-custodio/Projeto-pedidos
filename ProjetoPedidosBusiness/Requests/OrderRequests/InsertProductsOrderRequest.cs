using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class InsertProductsOrderRequest : IRequest<OrderCommandResult>
    {
        public string Id { get; set; } = "";
        public string ProductId { get; set; } = "";
    }
}
