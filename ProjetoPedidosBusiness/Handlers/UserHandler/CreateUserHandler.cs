using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, object>
    {
        private readonly IUserService _Service;

        public CreateUserHandler(IUserService service)
        {
            _Service = service;
        }

        //public ICommandResult DeleteUser(string id)
        //{
        //    try
        //    {
        //        _Service.Delete(id);
        //    }
        //    catch (Exception e)
        //    {

        //        return new CommandResult(false, "Usuário não encontrado", e.Message);
        //    }

        //    return new CommandResult(true, $"Usuário id = ( {id} ) excluido com sucesso !", null);
        //}

        //public ICommandResult GetAllUsers()
        //{
        //  
        //}

        //public ICommandResult GetUserById(string id)
        //{
        //    var user = new User();

        //    try
        //    {
        //        var result = _Service.GetById(id);

        //        user.Id = result.Id;
        //        user.Name = result.Name;
        //        user.Email = result.Email;
        //        user.CPF = result.CPF;

        //    }
        //    catch (Exception e)
        //    {

        //        return new CommandResult(false, "Falha ao Buscar o usuário", e.Message);
        //    }

        //    return new CommandResult(true, "Usuário encontrado com sucesso !", user);
        //}

        //public ICommandResult UpadateUser(string id, User user)
        //{
        //    try
        //    {
        //        var result = _Service.Update(id, user);

        //        user.Id = result.Id;
        //        user.Name = result.Name;
        //        user.Email = result.Email;
        //        user.CPF = result.CPF;

        //    }
        //    catch (Exception e)
        //    {

        //        return new CommandResult(false, "Falha ao atualizar o usuário", e.Message);
        //    }

        //    return new CommandResult(true, "Usuário atualizado com sucesso !", user);
        //}

        //private bool CheckCpf(string cpf)
        //{
        //    var result = _Service.GetByCpf(cpf);
        //    if (result == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public async Task<object> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                CPF = request.CPF
            };

            var result = _Service.Create(user);

            return await Task.FromResult(result);
        }

    }
}
