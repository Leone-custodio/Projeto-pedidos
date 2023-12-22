using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.OrderRequests;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("Oder/")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createOrder/{userName},{userCpf},{productName}")]
        public async Task<object> CreateProduct([FromRoute] string userName, string userCpf, string productName)
        {
            var request = new CreateOrderRequest()
            {
                UserName = userName,
                UserCpf = userCpf,
                Product = productName
            };

            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("insertProducOrder/{id},{productName}")]
        public async Task<object> InsertProduct([FromRoute] string id, string productName)
        {
            var request = new InsertProductsOrderRequest()
            {
                Id = id,
                Product = productName
            };

            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("insertProducOrder/{id},{productName}")]
        public async Task<object> RemoveProduct([FromRoute] string id, string productName)
        {
            var request = new RemoveProductOrderRequest()
            {
                Id = id,
                Product = productName
            };

            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("deleteOrder/{id}")]
        public async Task<object> DeleteOrder([FromRoute] string id)
        {
            var request = new DeleteOrderRequest()
            {
                Id = id
            };
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public  async Task<object> GetOrderById([FromRoute] string id)
        {
            var request = new GetOrderByIdRequest()
            {
                Id = id
            };
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAllOrders")]
        public async Task<object> GetAllOrders()
        {
            var request = new GetAllOrdersRequest();
            return await _mediator.Send(request);
        }
    }
}
