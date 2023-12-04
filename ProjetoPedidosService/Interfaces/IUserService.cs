using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IUserService
    {
        CommandResult Create(User user);
        CommandResult GetById(string id);
        CommandResult GetAll();
        CommandResult Update(string id, User user);
        CommandResult Delete(string id);
    }
}
