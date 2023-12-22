using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosBusiness.Requests.UserRequests;

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
        [Route("create/{name},{email},{cpf}")]
        public async Task<object> CreateUser([FromRoute] string name, string email, string cpf)
        {
            var request = new CreateUserRequest()
            { 
                Name = name,
                Email = email,
                CPF = cpf
            };
           
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAllUsers/")]
        public async Task<object> GetAllUsers( )       
        {
            var request = new GetAllUsersRequest();
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<object> GetById([FromRoute] string id)
        {
            var request = new GetByIdRequest()
            {
                Id = id
            };
            return await _mediator.Send(request); ;
        }

        [HttpPut]
        [Route("update/{id},{name},{email},{cpf}")]
        public async Task<object> UpdateUser([FromRoute] string id, string name, string email, string cpf)
        {
            var request = new UpdateUserRequest()
            {
                Id = id,
                Name = name,
                Email = email,
                CPF = cpf
            };

            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<object> Delete([FromRoute] string id)
        {
            var request = new DeleteUserRequest()
            {
                Id = id
            };
            return await _mediator.Send(request); ;
        }
    }
}
