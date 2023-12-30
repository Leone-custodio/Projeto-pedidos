using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, OrderCommandResult>
    {
        private readonly IOrderService _service;

        public GetAllOrdersHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderCommandResult> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetAll();
            return await Task.FromResult(result);
        }
    }
}
