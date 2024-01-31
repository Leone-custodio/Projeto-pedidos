using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, OrderCommandResult>
    {
        private readonly IOrderService _service;

        public CreateOrderHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderCommandResult> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var result = _service.Create(request.ProductId, request.UserCpf);
            return await Task.FromResult(result);
        }
    }
}
