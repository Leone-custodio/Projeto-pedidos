using MediatR;
using ProjetoPedidosService.Commands;
namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class CreateOrderRequest : IRequest<OrderCommandResult>
    {
        public string? UserCpf { get; set; } 
        public string? ProductId { get; set; } 
    }
}
