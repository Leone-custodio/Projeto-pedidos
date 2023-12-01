using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Handlers;
using ProjetoPedidosBusiness.Handlers.UserHandler;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("v1/users/")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("create/{name},{email},{cpf}")]
        public Task<object> CreateUser(
            [FromRoute] string name, string email, string cpf,
            [FromServices] IMediator mediator,
            [FromBody] CreateUserRequest request)
        {
            request.Name = name;
            request.Email = email;
            request.CPF = cpf;

            return mediator.Send(request);
        }

        [HttpOptions]
        [Route("getAllUsers/")]
        public async Task<object> GetAllUsers(
            [FromServices] IMediator mediator,
            [FromBody] GetAllUsersRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpOptions]
        [Route("getById/{id}")]
        public async Task<object> GetById(
            [FromRoute] string id,
            [FromServices] IMediator mediator,
            [FromBody] GetByIdRequest request)
        {
            request.Id = id;
            return await mediator.Send(request); ;
        }

        [HttpPut]
        [Route("update/{id},{name},{email},{cpf}")]
        public Task<object> UpdateUser(
            [FromRoute] string id, string name, string email, string cpf,
            [FromServices] IMediator mediator,
            [FromBody] UpdateUserRequest request)
        {
            request.Id = id;
            request.Name = name;
            request.Email = email;
            request.CPF = cpf;

            return mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<object> Delete(
            [FromRoute] string id,
            [FromServices] IMediator mediator,
            [FromBody] DeleteUserRequest request)
        {
            request.Id = id;
            return await mediator.Send(request); ;
        }
    }
}
