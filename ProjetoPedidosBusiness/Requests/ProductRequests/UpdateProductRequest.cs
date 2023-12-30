using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class UpdateProductRequest : IRequest<ProductCommandResult>
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";
    }
}
