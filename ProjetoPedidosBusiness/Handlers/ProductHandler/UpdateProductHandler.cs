using MediatR;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.ProductHandler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ProductCommandResult>
    {
        private readonly IProductService _service;

        public UpdateProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<ProductCommandResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Category = request.Category,
                Description = request.Description
            };
            var result = _service.Update(request.Id, product);
            return await Task.FromResult(result);
        }
    }
}
