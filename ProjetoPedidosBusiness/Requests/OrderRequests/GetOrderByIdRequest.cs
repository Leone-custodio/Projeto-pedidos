using MediatR;

namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class GetOrderByIdRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
    }
}
