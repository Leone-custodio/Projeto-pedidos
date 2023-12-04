using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Interfaces
{
    public interface IOrderRepository
    {
        Order Create(Order order);
        Order GetById(string id);
        List<Order> GetAll();
        Order Update(string id, Order order);
        void Delete(string id);
    }
}
