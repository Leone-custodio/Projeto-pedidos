using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("v1/Oder/")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createOrder/{userCpf}/{productId}")]
        public async Task<OrderCommandResult> CreateOrder([FromRoute] string userCpf, string productId)
        {
            var request = new CreateOrderRequest()
            {
                UserCpf = userCpf,
                ProductId = productId
            };

            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("insertProducOrder/{id}/{productId}")]
        public async Task<OrderCommandResult> InsertProduct([FromRoute] string id, string productId)
        {
            var request = new InsertProductsOrderRequest()
            {
                Id = id,
                ProductId = productId
            };

            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("deleteProducOrder/{id}/{productId}")]
        public async Task<OrderCommandResult> RemoveProduct([FromRoute] string id, string productId)
        {
            var request = new RemoveProductOrderRequest()
            {
                Id = id,
                ProductId = productId
            };

            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("deleteOrder/{id}")]
        public async Task<OrderCommandResult> DeleteOrder([FromRoute] string id)
        {
            var request = new DeleteOrderRequest()
            {
                Id = id
            };
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public  async Task<OrderCommandResult> GetOrderById([FromRoute] string id)
        {
            var request = new GetOrderByIdRequest()
            {
                Id = id
            };
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAllOrders")]
        public async Task<OrderCommandResult> GetAllOrders()
        {
            var request = new GetAllOrdersRequest();
            return await _mediator.Send(request);
        }
    }
}
