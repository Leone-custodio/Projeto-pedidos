using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Interfaces;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public CommandResult Create(Product product)
        {
            if (GetProductName(product.Name) == false)
            {
                _repository.Create(product);

                return new CommandResult(true, "Produto cadastrado com sucesso!", new
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Category
                });
            }
            else
            {
                return new CommandResult(false, $"Já existi um cadastro para {product.Name} no sistema !", false);
            };
        }

        public CommandResult Delete(string id)
        {
            var delete = _repository.GetById(id);
            if (delete == null)
            {
                return new CommandResult(false, $"Não existi um cadastro para id {id} no sistema !", false);
            }
            else
            {
                _repository.Delete(id);
                return new CommandResult(true, "Produto excluid com sucesso !", true);
            }
        }

        public List<Product> GetAll()
        {
            var list = _repository.GetAll();
            return list;
        }

        public CommandResult GetById(string id)
        {
            var product = _repository.GetById(id);

            if (product == null)
            {
                return new CommandResult(false, $"Produto id {id} não está cadastrado no sistema", false);
            }
            else
            {
                return new CommandResult(true, "Produto encontrado com sucesso !", new
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Category
                });
            }
        }

        public Product Update(string id, Product product)
        {
            _repository.Update(id, product);
            return product;
        }

        private bool GetProductName(string name)
        {
            name.ToUpper();

            var searchName = _repository.GetByName(name);
            if (searchName == null)
            {
                return false;
            }

            return true;
        }
    }
}
