using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IOrderService
    {
        OrderCommandResult Create(string productId, string userCpf);
        OrderCommandResult InsertProductOrder(string id, string productId);
        OrderCommandResult RemoveProductOrder(string id, string productId);
        OrderCommandResult GetById(string id);
        OrderCommandResult GetByUserCpf(string userCpf);
        OrderCommandResult GetAll();
        OrderCommandResult Delete(string id);
    }
}
