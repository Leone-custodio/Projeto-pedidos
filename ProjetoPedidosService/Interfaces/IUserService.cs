using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IUserService
    {
        UserCommandResult Create(User user);
        UserCommandResult GetByCpf(string cpf);
        UserCommandResult GetAll();
        UserCommandResult Update(string id, User user);
        UserCommandResult GetPassword(string cpf, string password);
        UserCommandResult UpdatePassword(string? cpf, string? password, string? newPassword);
        UserCommandResult Delete(string id);
    }
}
