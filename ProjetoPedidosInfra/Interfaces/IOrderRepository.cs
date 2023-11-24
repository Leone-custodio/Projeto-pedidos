using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> Create(Order order);
        Task<Order> GetById(Guid id);
        Task<Order> GetAll();
        Task<Order> Update(Guid id);
        Task<Order> Delete(Guid id);
    }
}
