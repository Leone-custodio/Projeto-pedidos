using MediatR;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.ProductHandler
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, object>
    {
        private readonly IProductService _service;

        public GetAllProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<object> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetAll();
            return await Task.FromResult(result);
        }
    }
}
