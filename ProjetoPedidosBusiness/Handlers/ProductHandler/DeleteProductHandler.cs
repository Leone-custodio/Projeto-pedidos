using MediatR;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.ProductHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, object>
    {
        private readonly IProductService _service;

        public DeleteProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<object> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var result = _service.Delete(request.Id);
            return await Task.FromResult(result);
        }
    }
}
