using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IOrderService
    {
        CommandResult Create(string productName, string userCpf);
        CommandResult InsertProductOrder(string id, string productName);
        CommandResult RemoveProductOrder(string id, string productName);
        CommandResult GetById(string id);
        CommandResult GetAll();
        CommandResult Delete(string id);
    }
}
