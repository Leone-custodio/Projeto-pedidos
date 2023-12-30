using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, UserCommandResult>
    {
        private readonly IUserService _service;

        public LoginUserHandler(IUserService service)
        {
            _service = service;
        }

        public Task<UserCommandResult> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetPassword(request.Cpf, request.Password);
            return Task.FromResult(result);
        }
    }
}
