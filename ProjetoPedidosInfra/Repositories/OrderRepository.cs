using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Interfaces;

namespace ProjetoPedidosInfra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order> Create(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
