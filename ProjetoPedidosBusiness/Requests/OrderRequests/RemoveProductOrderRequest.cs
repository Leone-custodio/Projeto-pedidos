using MediatR;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class RemoveProductOrderRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
        public string Product { get; set; } = "";
    }
}
