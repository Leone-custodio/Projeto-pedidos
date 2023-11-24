using ProjetoPedidosBusiness.Commands.Requests;
using ProjetoPedidosBusiness.Commands.Responses;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Commands.Handlers
{
    public class CreateUserHandler 
    {
        private readonly IUserService _Service;

        public CreateUserHandler(IUserService service)
        {
            _Service = service;
        }

        public Task<CreateUserResponse> Handle(CreateUserRequest request)
        {

            var response = new CreateUserResponse()
            {
                Name = request.Name,
                Email = request.Email,
                CPF = request.CPF
            };

            if (response != null)
            {
                _Service.Create(response.Name, response.Email, response.CPF);
            }

            return Task.FromResult(response);

        }
    }
}
