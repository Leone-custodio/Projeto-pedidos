using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class DeleteProductRequest : IRequest<ProductCommandResult>
    {
        public string Id { get; set; } = "";
    }
}
