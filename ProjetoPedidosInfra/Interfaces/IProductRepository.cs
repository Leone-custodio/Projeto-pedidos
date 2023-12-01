using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Interfaces
{
    public interface IProductRepository
    {
        Product Create(Product product);
        Product GetById(string id);
        Product GetByName(string name);
        List<Product> GetAll();
        Product Update(string id, Product product);
        void Delete(string id);
    }
}
