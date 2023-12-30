using MediatR;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.ProductHandler
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, ProductCommandResult>
    {
        private readonly IProductService _service;

        public GetAllProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<ProductCommandResult> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetAll();
            return await Task.FromResult(result);
        }
    }
}
