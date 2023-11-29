using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetById(string id);
        User GetByCpf(string cpf);
        List<User> GetAll();
        User Update(string id, User user);
        void Delete(string id);
    }
}
