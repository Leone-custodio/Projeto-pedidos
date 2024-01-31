using MongoDB.Driver;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Data;
using ProjetoPedidosInfra.Interfaces;

namespace ProjetoPedidosInfra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbProjectContext _context;
        public OrderRepository(DbProjectContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            _context.Orders.InsertOne(order);
            return order;
        }

        public void Delete(string id)
        {
           _context.Orders.FindOneAndDelete(x => x.Id == id);
        }

        public List<Order> GetAll()
        {
            var result = _context.Orders.Find(x => true).ToList();
            return result;
        }

        public Order GetById(string id)
        {
            var result = _context.Orders.Find(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<Order> GetByUserCpf(string userCpf)
        {
            var result = _context.Orders.Find(x => x.UserCpf == userCpf).ToList();
            return result;
        }

        public Order Update(string id, Order order )
        {
            _context.Orders.ReplaceOne(x => x.Id == id, order);
            return order;
        }
    }
}
