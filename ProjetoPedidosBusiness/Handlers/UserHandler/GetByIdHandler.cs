using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class GetByCpfHandler : IRequestHandler<GetByCpfRequest, UserCommandResult>
    {
        private readonly IUserService _service;

        public GetByCpfHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UserCommandResult> Handle(GetByCpfRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetByCpf(request.Cpf);

            return  await Task.FromResult( result);
        }
    }
}
