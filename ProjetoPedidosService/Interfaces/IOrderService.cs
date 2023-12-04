using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IOrderService
    {
        CommandResult Create(string productName, string userCpf);
        CommandResult GetById(string id);
        CommandResult GetAll();
        CommandResult Update(string id, Order order);
        void Delete(string id);
    }
}
