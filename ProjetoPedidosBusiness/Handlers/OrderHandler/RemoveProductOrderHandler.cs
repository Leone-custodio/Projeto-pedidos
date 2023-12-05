using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class RemoveProductOrderHandler : IRequestHandler<RemoveProductOrderRequest, object>
    {
        private readonly IOrderService _service;

        public RemoveProductOrderHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<object> Handle(RemoveProductOrderRequest request, CancellationToken cancellationToken)
        {
            var result = _service.RemoveProductOrder(request.Id, request.Product);
            return await Task.FromResult(result);
        }
    }
}
