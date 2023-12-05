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
                product.Name = ToUperName(product.Name);

                _repository.Create(product);

                return new CommandResult(true, "Produto cadastrado com sucesso!", new
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Category
                });
            }

            return new CommandResult(false, $"Já existi um cadastro para {product.Name} no sistema !", false);
        }

        public CommandResult Delete(string id)
        {
            var delete = _repository.GetById(id);
            if (delete == null)
            {
                return new CommandResult(false, $"Não existi um cadastro para id {id} no sistema !", false);
            }

            _repository.Delete(id);
            return new CommandResult(true, "Produto excluido com sucesso !", true);
        }

        public CommandResult GetAll()
        {
            var list = _repository.GetAll();

            if (list.Count == 0)
            {
                return new CommandResult(true, "Não existem produtos cadastrados no sistema no momento!", list);
            }

            return new CommandResult(true, "Busca completada com sucesso !", list);
        }

        public CommandResult GetById(string id)
        {
            var product = _repository.GetById(id);

            if (product == null)
            {
                return new CommandResult(false, $"Produto id {id} não está cadastrado no sistema", false);
            }

            return new CommandResult(true, "Produto encontrado com sucesso !", new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Category
            });
        }

        public CommandResult Update(string id, Product product)
        {
            var update = _repository.GetById(id);
            if (update == null)
            {
                return new CommandResult(false, $"Produto id {id} não existe no sistema !", false);
            }

            product.Name = ToUperName(product.Name);

            _repository.Update(id, product);

            return new CommandResult(true, "Produto atualizado com sucesso !", product);
        }

        private bool GetProductName(string name)
        {
            var searchName = _repository.GetByName(ToUperName(name));
            if (searchName == null)
            {
                return false;
            }

            return true;
        }

        private string ToUperName(string name)
        {
            var toUpperName = name.ToUpper();
            return toUpperName;
        }
    }
}
