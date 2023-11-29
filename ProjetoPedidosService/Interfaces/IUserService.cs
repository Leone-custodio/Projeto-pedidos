using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosService.Interfaces
{
    public interface IUserService
    {
        User Create(User user);
        User GetById(string id);
        User GetByCpf(string cpf);
        List<User> GetAll();
        User Update(string id, User user);
        void Delete(string id);
    }
}
