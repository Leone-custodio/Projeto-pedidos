using MediatR;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class DeleteProductRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
    }
}
