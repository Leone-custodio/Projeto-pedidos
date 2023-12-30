using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class InsertProductsOrderHandler : IRequestHandler<InsertProductsOrderRequest, OrderCommandResult>
    {
        private readonly IOrderService _service;

        public InsertProductsOrderHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderCommandResult> Handle(InsertProductsOrderRequest request, CancellationToken cancellationToken)
        {
            var result = _service.InsertProductOrder(request.Id, request.Product);
            return await Task.FromResult(result);
        }
    }
}
