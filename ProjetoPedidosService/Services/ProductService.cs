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

        public ProductCommandResult Create(Product product)
        {
            if (GetProductName(product.Name) == false)
            {
                product.Name = ToUperName(product.Name);

                _repository.Create(product);

                return ProductCommandResult.Result(true, "Produto cadastrado com sucesso!", product); 
              
            }

            return ProductCommandResult.Result(false, $"Já existi um cadastro para {product.Name} no sistema !", null);
        }

        public ProductCommandResult Delete(string id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return ProductCommandResult.Result(false, $"Não existi um cadastro para id {id} no sistema !", null);
            }

            _repository.Delete(id);
            return ProductCommandResult.Result(true, "Produto excluido com sucesso !", product);
        }

        public ProductCommandResult GetAll()
        {
            var list = _repository.GetAll();

            if (list.Count != 0)
            {
                return ProductCommandResult.ResultList(true,"Busca Completada com sucesso", list);
            }

            return ProductCommandResult.ResultList(true, "Busca Completada com sucesso", list);
        }

        public ProductCommandResult GetById(string id)
        {
            var product = _repository.GetById(id);

            if (product == null)
            {
                return ProductCommandResult.Result(false, $"Produto id {id} não está cadastrado no sistema", null);
            }

            return ProductCommandResult.Result(true, "Produto encontrado com sucesso !",product );
          
        }

        public ProductCommandResult Update(string id, Product product)
        {
            var update = _repository.GetById(id);
            if (update == null)
            {
                return ProductCommandResult.Result(false, $"Produto id {id} não existe no sistema !", product);
            }

            product.Name = ToUperName(product.Name);

            _repository.Update(id, product);

            return ProductCommandResult.Result(true, "Produto atualizado com sucesso !", product);
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
