using MediatR;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.ProductHandler
{
    public class ProductHandler : IRequestHandler<CreateProductRequest, ProductCommandResult>
    {
        private readonly IProductService _Service;

        public ProductHandler(IProductService service)
        {
            _Service = service;
        }

        public async Task<ProductCommandResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Price = request.Price,
                Category = request.Category,
            };

            var result = _Service.Create(product);

            return await Task.FromResult( result);
        }
    }
}
