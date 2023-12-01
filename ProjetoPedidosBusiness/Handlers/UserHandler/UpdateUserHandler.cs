using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, object>
    {
        private readonly IUserService _service;

        public UpdateUserHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<object> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                CPF = request.CPF
            };
            var result = _service.Update(request.Id,user);
            return await Task.FromResult(result);
        }
    }
}
