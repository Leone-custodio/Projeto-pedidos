using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Interfaces;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> Create(string name, string email, string cpf)
        {
            var user = _repository.Create(name, email, cpf);

            return user;
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
