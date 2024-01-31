using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create/{name}/{price}/{category}/{description}")]
        public Task<ProductCommandResult> CreateProduct([FromRoute] string name, decimal price, string category, string description)
        {
            var request = new CreateProductRequest()
            {
                Name = name,
                Price = price,
                Category = category,
                Description = description
            };

            return _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAllProducts")]
        public Task<ProductCommandResult> GetAllProduct()
        {
            var request = new GetAllProductRequest();
            return _mediator.Send(request);
        }

        [HttpGet]
        [Route("getByIdProducts/{id}")]
        public Task<ProductCommandResult> GetByIdProduct([FromRoute] string id)
        {
            var request = new GetByIdProductRequest()
            {
                Id = id
            };
            return _mediator.Send(request);
        }

        [HttpPut]
        [Route("update/{id}/{name}/{price}/{category}/{description}")]
        public Task<ProductCommandResult> UpdateProduct([FromRoute] string id, string name, decimal price, string category, string description)
        {
            var request = new UpdateProductRequest()
            {
                Id = id,
                Name = name,
                Price = price,
                Category = category,
                Description = description
            };

            return _mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<ProductCommandResult> DeleteProduct([FromRoute] string id)
        {
            var request = new DeleteProductRequest()
            {
                Id= id
            };

            return _mediator.Send(request);
        }
    }
}
