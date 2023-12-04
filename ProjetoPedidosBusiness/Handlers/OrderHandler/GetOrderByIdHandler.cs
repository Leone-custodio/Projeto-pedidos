using MediatR;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.OrderHandler
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, object>
    {
        private readonly IOrderService _service;

        public GetOrderByIdHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<object> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetById(request.Id);
            return await Task.FromResult(result);
        }
    }
}
