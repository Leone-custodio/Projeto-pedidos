using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IProductService
    {
        ProductCommandResult Create(Product product);
        ProductCommandResult GetById(string id);
        ProductCommandResult GetAll();
        ProductCommandResult Update(string id, Product product);
        ProductCommandResult Delete(string id);
    }
}
