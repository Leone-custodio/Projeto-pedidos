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
            
    }
}
