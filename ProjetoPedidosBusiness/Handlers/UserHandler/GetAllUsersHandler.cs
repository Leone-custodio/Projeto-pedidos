using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, UserCommandResult>
    {
        private readonly IUserService _Service;

        public GetAllUsersHandler(IUserService service)
        {
            _Service = service;
        }

        public async Task<UserCommandResult> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var result = _Service.GetAll();
            return await Task.FromResult(result);
        }
    }
}
