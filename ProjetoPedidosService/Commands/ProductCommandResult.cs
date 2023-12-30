using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Commands
{
    public class ProductCommandResult : IProductCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static ProductResult Result (bool success, string message, Product? product)
        {
            return new ProductResult {  Success = success, Message = message, Product = product };
        }

        public static ProductListResult ResultList(bool success, string message, List<Product>? products)
        {
            return new ProductListResult { Success = success, Message = message, Products = products };
        }
    }

    public class ProductResult : ProductCommandResult
    {
        public Product? Product { get; set; }
    }

    public class ProductListResult : ProductCommandResult
    {
        public List<Product>? Products { get; set; }

    }

}
