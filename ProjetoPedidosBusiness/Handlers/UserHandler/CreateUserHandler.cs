using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserCommandResult>
    {
        private readonly IUserService _Service;

        public CreateUserHandler(IUserService service)
        {
            _Service = service;
        }

        public async Task<UserCommandResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                CPF = request.CPF,
                Endereco = request.Endereco,
                Password = request.Password,
            };

            var result = _Service.Create(user);

            return await Task.FromResult(result);
        }

    }
}
