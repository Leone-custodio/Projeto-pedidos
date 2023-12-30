using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosAplication.Controllers
{
    [ApiController]
    [Route("v1/users/")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create/{name}/{email}/{cpf}/{endereco}/{password}")]
        public async Task<UserCommandResult> CreateUser([FromRoute] string name, string email, string cpf, string endereco, string password)
        {
            var request = new CreateUserRequest()
            { 
                Name = name,
                Email = email,
                CPF = cpf,
                Endereco = endereco,
                Password = password
            };
           
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAllUsers/")]
        public async Task<UserCommandResult> GetAllUsers( )       
        {
            var request = new GetAllUsersRequest();
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<UserCommandResult> GetById([FromRoute] string id)
        {
            var request = new GetByIdRequest()
            {
                Id = id
            };
            return await _mediator.Send(request); ;
        }

        [HttpGet]
        [Route("getPassword/{cpf}/{password}")]
        public async Task<UserCommandResult> GetById([FromRoute] string cpf, string password)
        {
            var request = new LoginUserRequest()
            {
                Password = password,
                Cpf = cpf
            };
            return await _mediator.Send(request); ;
        }
        [HttpPut]
        [Route("updatePassword/{cpf}/{password}/{newPassword}")]
        public async Task<UserCommandResult> UpdatePassword([FromRoute] string cpf, string password, string newPassword)
        {
            var request = new UpdatePasswordRequest()
            {
                Cpf = cpf,
                Password = password,
                NewPassword = newPassword
            };
            return await _mediator.Send(request); ;
        }

        [HttpPut]
        [Route("update/{id}/{name}/{email}/{cpf}/{endereco}")]
        public async Task<UserCommandResult> UpdateUser([FromRoute] string id, string name, string email, string cpf, string endereco)
        {
            var request = new UpdateUserRequest()
            {
                Id = id,
                Name = name,
                Email = email,
                CPF = cpf,
                Endereco = endereco
            };

            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<UserCommandResult> Delete([FromRoute] string id)
        {
            var request = new DeleteUserRequest()
            {
                Id = id
            };
            return await _mediator.Send(request); ;
        }
    }
}
