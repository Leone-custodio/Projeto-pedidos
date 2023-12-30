using MediatR;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class GetAllProductRequest : IRequest<ProductCommandResult>
    {
        public ProductCommandResult? Result { get; set; }
    }
}
