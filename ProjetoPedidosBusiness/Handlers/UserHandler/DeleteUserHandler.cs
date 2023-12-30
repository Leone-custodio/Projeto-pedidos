using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, UserCommandResult>
    {
        private readonly IUserService _service;

        public DeleteUserHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UserCommandResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var result = _service.Delete(request.Id);
            return await Task.FromResult(result);
        }
    }
}
