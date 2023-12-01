using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IUserService
    {
        CommandResult Create(User user);
        CommandResult GetById(string id);
        List<User> GetAll();
        CommandResult Update(string id, User user);
        CommandResult Delete(string id);
    }
}
