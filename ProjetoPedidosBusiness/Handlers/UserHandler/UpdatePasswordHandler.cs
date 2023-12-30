using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordRequest, UserCommandResult>
    {
        private readonly IUserService _service;

        public UpdatePasswordHandler(IUserService service)
        {
            _service = service;
        }

        public Task<UserCommandResult> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            var result = _service.UpdatePassword(request.Cpf, request.Password, request.NewPassword);
            return Task.FromResult(result);
        }
    }
}
