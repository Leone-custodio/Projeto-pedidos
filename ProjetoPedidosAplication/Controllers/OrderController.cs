using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.OrderRequests;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("Oder/")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("createOrder/{userName},{userCpf},{productName}")]
        public Task<object> CreateProduct(
            [FromRoute] string userName, string userCpf, string productName,
            [FromServices] IMediator mediator,
            [FromBody] CreateOrderRequest request)
        {
            request.UserName = userName;
            request.UserCpf = userCpf;
            request.Product = productName;

            return mediator.Send(request);
        } 
        
        [HttpPost]
        [Route("insertProducOrder/{id},{productName}")]
        public async Task<object> InsertProduct(
            [FromRoute] string id, string productName,
            [FromServices] IMediator mediator,
            [FromBody] InsertProductsOrderRequest request)
        {
            request.Id = id;
            request.Product = productName;

            return await mediator.Send(request);
        } 
        
        [HttpDelete]
        [Route("insertProducOrder/{id},{productName}")]
        public async Task<object> RemoveProduct(
            [FromRoute] string id, string productName,
            [FromServices] IMediator mediator,
            [FromBody] RemoveProductOrderRequest request)
        {
            request.Id = id;
            request.Product = productName;

            return await mediator.Send(request);
        } 

        [HttpDelete]
        [Route("deleteOrder/{id}")]
        public async Task<object> DeleteOrder(
            [FromRoute] string id,
            [FromServices] IMediator mediator,
            [FromBody] DeleteOrderRequest request)
        {
            request.Id = id;
            return await mediator.Send(request);
        }

        [HttpOptions]
        [Route("getById/{id}")]
        public Task<object> GetOrderById(
            [FromRoute] string id,
            [FromServices] IMediator mediator,
            [FromBody] GetOrderByIdRequest request)
        {
            request.Id = id;
            return mediator.Send(request);
        }

        [HttpOptions]
        [Route("getAllOrders")]
        public async Task<object> GetAllOrders(
            [FromServices] IMediator mediator,
            [FromBody] GetAllOrdersRequest request )
        {
            return await mediator.Send(request);
        }
    }
}
