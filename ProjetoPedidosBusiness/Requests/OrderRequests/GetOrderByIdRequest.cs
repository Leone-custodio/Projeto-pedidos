using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class GetOrderByIdRequest : IRequest<OrderCommandResult>
    {
        public string Id { get; set; } = "";
    }
}
