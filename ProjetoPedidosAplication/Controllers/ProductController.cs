using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.ProductRequests;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create/{name},{price},{category}")]
        public Task<object> CreateProduct([FromRoute] string name, decimal price, string category)
        {
            var request = new CreateProductRequest()
            {
                Name = name,
                Price = price,
                Category = category
            };

            return _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAllProducts")]
        public Task<object> GetAllProduct()
        {
            var request = new GetAllProductRequest();
            return _mediator.Send(request);
        }

        [HttpGet]
        [Route("getByIdProducts/{id}")]
        public Task<object> GetByIdProduct([FromRoute] string id)
        {
            var request = new GetByIdProductRequest()
            {
                Id = id
            };
            return _mediator.Send(request);
        }

        [HttpPut]
        [Route("update/{id},{name},{price},{category}")]
        public Task<object> UpdateProduct([FromRoute] string id, string name, decimal price, string category)
        {
            var request = new UpdateProductRequest()
            {
                Id = id,
                Name = name,
                Price = price,
                Category = category
            };

            return _mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<object> DeleteProduct([FromRoute] string id)
        {
            var request = new DeleteProductRequest()
            {
                Id= id
            };

            return _mediator.Send(request);
        }
    }
}
