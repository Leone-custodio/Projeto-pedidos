using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class GetOrdersByUserCpfRequest : IRequest<OrderCommandResult>
    {
        public string UserCpf { get; set; } = "";
    }
}
