using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IOrderService
    {
        OrderCommandResult Create(string productName, string userCpf);
        OrderCommandResult InsertProductOrder(string id, string productName);
        OrderCommandResult RemoveProductOrder(string id, string productName);
        OrderCommandResult GetById(string id);
        OrderCommandResult GetAll();
        OrderCommandResult Delete(string id);
    }
}
