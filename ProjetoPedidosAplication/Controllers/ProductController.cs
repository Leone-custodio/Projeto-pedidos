using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("create/{name},{price},{category}")]
        public Task<object> CreateProduct(
            [FromRoute] string name, decimal price, string category,
            [FromServices] IMediator mediator,
            [FromBody] CreateProductRequest request)
        {
            request.Name = name;
            request.Price = price;
            request.Category = category;

            return mediator.Send(request);
        }

        [HttpOptions]
        [Route("getAllProducts")]
        public Task<object> GetAllProduct(
            [FromServices] IMediator mediator,
            [FromBody] GetAllProductRequest request)
        {
            return mediator.Send(request);

        }

        [HttpOptions]
        [Route("getByIdProducts/{id}")]
        public Task<object> GetByIdProduct(
            [FromRoute] string id,
            [FromServices] IMediator mediator,
            [FromBody] GetByIdProductRequest request)
        {
            request.Id = id;
            return mediator.Send(request);
        }

        [HttpPut]
        [Route("update/{id},{name},{price},{category}")]
        public Task<object> UpdateProduct(
            [FromRoute] string id, string name, decimal price, string category,
            [FromServices] IMediator mediator,
            [FromBody] UpdateProductRequest request)
        {
            request.Id = id;
            request.Name = name;
            request.Price = price;
            request.Category = category;

            return mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<object> DeleteProduct(
            [FromRoute] string id,
            [FromServices] IMediator mediator,
            [FromBody] DeleteProductRequest request)
        {
            request.Id = id;
            return mediator.Send(request);
        }
    }
}
