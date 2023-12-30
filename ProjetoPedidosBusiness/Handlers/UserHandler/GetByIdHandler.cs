using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class GetByIdHandler : IRequestHandler<GetByIdRequest, UserCommandResult>
    {
        private readonly IUserService _service;

        public GetByIdHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UserCommandResult> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetById(request.Id);

            return  await Task.FromResult( result);
        }
    }
}
