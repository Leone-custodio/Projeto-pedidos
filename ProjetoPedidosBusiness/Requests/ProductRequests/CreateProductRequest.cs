using MediatR;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class CreateProductRequest : IRequest<object>
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";
    }
}
