using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);
        Task<Product> GetById(Guid id);
        Task<Product> GetAll();
        Task<Product> Update(Guid id);
        Task<Product> Delete(Guid id);
    }
}
