using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Interfaces;

namespace ProjetoPedidosInfra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
