using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class GetOrdersByUserCpfHandler : IRequestHandler<GetOrdersByUserCpfRequest, OrderCommandResult>
    {
        private readonly IOrderService _service;

        public GetOrdersByUserCpfHandler(IOrderService service)
        {
            _service = service;
        }

        public Task<OrderCommandResult> Handle(GetOrdersByUserCpfRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetByUserCpf(request.UserCpf);

            return Task.FromResult(result);
        }
    }
}
