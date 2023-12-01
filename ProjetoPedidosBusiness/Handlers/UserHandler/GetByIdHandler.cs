using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class GetByIdHandler : IRequestHandler<GetByIdRequest, object>
    {
        private readonly IUserService _service;

        public GetByIdHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<object> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetById(request.Id);

            return  await Task.FromResult( result);
        }
    }
}
