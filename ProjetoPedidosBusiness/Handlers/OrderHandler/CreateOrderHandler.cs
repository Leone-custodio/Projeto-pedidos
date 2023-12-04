using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, object>
    {
        private readonly IOrderService _service;

        public CreateOrderHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<object> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var result = _service.Create(request.Product, request.UserCpf);
            return await Task.FromResult(result);
        }
    }
}
