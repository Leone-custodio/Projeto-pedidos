using MediatR;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.ProductHandler
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, object>
    {
        private readonly IProductService _service;

        public GetByIdProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<object> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetById(request.Id);
            return await Task.FromResult(result);
        }
    }
}
