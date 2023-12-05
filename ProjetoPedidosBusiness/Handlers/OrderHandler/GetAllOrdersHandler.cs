using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, object>
    {
        private readonly IOrderService _service;

        public GetAllOrdersHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<object> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetAll();
            return await Task.FromResult(result);
        }
    }
}
