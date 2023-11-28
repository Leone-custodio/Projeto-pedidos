using ProjetoPedidosBusiness.Commands.Requests;
using ProjetoPedidosBusiness.Interfaces;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Commands.Handlers
{
    public class UserHandler
    {
        private readonly IUserService _Service;

        public UserHandler(IUserService service)
        {
            _Service = service;
        }

        public ICommandResult CreateUser(CreateUserRequest request)
        {

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                CPF = request.CPF
            };

            try
            {
                _Service.Create(user);
            }
            catch (Exception e)
            {

                return new CommandResult(false, "O usuário não pode ser nulo", e.Message);
            }

            return new CommandResult(true, "Usuário cadastrado com sucesso !", new
            {
                request.Name,
                request.Email,
                request.CPF
            });
        }

        public ICommandResult DeleteUser(string id)
        {
            try
            {
                _Service.Delete(id);
            }
            catch (Exception e)
            {

                return new CommandResult(false, "Usuário não encontrado", e.Message);
            }

            return new CommandResult(true, $"Usuário id = ( {id} ) excluido com sucesso !", null);
        }

        public ICommandResult GetAllUsers()
        {
            var list = new List<User>();

            try
            {
                var result = _Service.GetAll();
                foreach (var user in result)
                {
                    list.Add(user);
                }
            }
            catch (Exception e)
            {

                return new CommandResult(false, "Falha ao carregar os usuários", e.Message);
            }

            return new CommandResult(true, "Usuários carregados com sucesso !", list);
        }

        public ICommandResult GetUserById(string id)
        {
            var user = new User();

            try
            {
                var result = _Service.GetById(id);

                user.Id = result.Id;
                user.Name = result.Name;
                user.Email = result.Email;
                user.CPF = result.CPF;
               
            }
            catch (Exception e)
            {

                return new CommandResult(false, "Falha ao Buscar o usuário", e.Message);
            }

            return new CommandResult(true, "Usuário encontrado com sucesso !", user);
        }
        public ICommandResult UpadateUser(string id, User user)
        {
            try
            {
                var result = _Service.Update(id, user);

                user.Id = result.Id;
                user.Name = result.Name;
                user.Email = result.Email;
                user.CPF = result.CPF;

            }
            catch (Exception e)
            {

                return new CommandResult(false, "Falha ao atualizar o usuário", e.Message);
            }

            return new CommandResult(true, "Usuário atualizado com sucesso !", user);
        }
    }
}
