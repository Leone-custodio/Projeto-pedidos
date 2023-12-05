using MediatR;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class DeleteOrderRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
    }
}
