using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, object>
    {
        private readonly IOrderService _service;

        public DeleteOrderHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<object> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var result = _service.Delete(request.Id);
            return await Task.FromResult(result);
        }
    }
}
