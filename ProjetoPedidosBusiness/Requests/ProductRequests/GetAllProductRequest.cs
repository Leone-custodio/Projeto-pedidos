using MediatR;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosBusiness.Requests.ProductRequests
{
    public class GetAllProductRequest : IRequest<object>
    {
        public List<Product> ListProduct { get; set; }
    }
}
