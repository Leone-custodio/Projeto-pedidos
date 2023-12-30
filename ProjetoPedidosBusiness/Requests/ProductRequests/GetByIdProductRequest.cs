using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class GetByIdProductRequest : IRequest<ProductCommandResult>
    {
        public string Id { get; set; } = "";
    }
}
