using MediatR;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class GetByIdProductRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
    }
}
