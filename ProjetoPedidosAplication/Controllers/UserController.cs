using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Commands.Handlers;
using ProjetoPedidosBusiness.Commands.Requests;
using ProjetoPedidosBusiness.Commands.Responses;
using ProjetoPedidosBusiness.Interfaces;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("v1/users/")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("create/{name},{email},{cpf}")]
        public ICommandResult CreateUser(
            [FromRoute] string name, string email, string cpf,
            [FromServices] UserHandler handler,
            [FromBody] CreateUserRequest request)
        {
            request.Name = name;
            request.Email = email;
            request.CPF = cpf;

            return handler.CreateUser(request);
        }

        [HttpGet]
        [Route("getAllUsers/")]
        public ICommandResult GetAllUsers(
            [FromServices] UserHandler handler)
        {
            return handler.GetAllUsers();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public ICommandResult GetById(
            [FromRoute] string id,
            [FromServices] UserHandler handler)
        {
            return handler.GetUserById(id);
        }

        [HttpPut]
        [Route("update/{id},{name},{email},{cpf}")]
        public ICommandResult UpdateUser(
            [FromRoute] string id, string name, string email, string cpf,
            [FromServices] UserHandler handler)
        {
            var user = new User() {Id = id, Name = name, Email = email, CPF = cpf };    
            return handler.UpadateUser(id, user);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ICommandResult DeleteUser(
           [FromRoute] string id,
           [FromServices] UserHandler handler)
        {
            return handler.DeleteUser(id);
        }
    }
}
