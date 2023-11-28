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

        public User Create(User user)
        {
            var result = _repository.Create(user);

            return result;
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            var list = _repository.GetAll();
            return list;
        }

        public User GetById(string id)
        {
            User user = _repository.GetById(id);

            return user;
        }

        public User Update(string id, User user)
        {
             _repository.Update(id, user);
            return user;
        }
    }
}
