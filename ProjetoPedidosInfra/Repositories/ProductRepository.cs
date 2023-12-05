using MongoDB.Driver;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Data;
using ProjetoPedidosInfra.Interfaces;

namespace ProjetoPedidosInfra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbProjectContext _context;

        public ProductRepository(DbProjectContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {

            _context.Products.InsertOne(product);
            return product;
        }

        public void Delete(string id)
        {
            _context.Products.FindOneAndDelete(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            var produts = _context.Products.Find(x => true).ToList();
            return produts;
        }

        public Product GetById(string id)
        {
            var product = _context.Products.Find(x => x.Id == id).FirstOrDefault();
            return product;
        }

        public Product GetByName(string name)
        {
            var product = _context.Products.Find(x => x.Name == name).FirstOrDefault();
            return product;
        }

        public Product Update(string id, Product product)
        {
            _context.Products.ReplaceOne(x => x.Id == id, product);
            return product;
        }
    }
}
