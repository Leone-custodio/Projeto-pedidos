using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Commands.Handlers;
using ProjetoPedidosBusiness.Commands.Requests;
using ProjetoPedidosBusiness.Commands.Responses;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("v1/users/")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route ("create/{name},{email},{cpf}")]
        public Task<CreateUserResponse> CreateUser(
            [FromRoute] string name, string email, string cpf,
            [FromServices] CreateUserHandler handler,
            [FromBody] CreateUserRequest request
            )
            {
            request.Name = name;
            request.Email = email;
            request.CPF = cpf;

            return handler.Handle(request);
        }
    }
}
