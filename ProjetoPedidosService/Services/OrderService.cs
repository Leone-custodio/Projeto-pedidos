using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Interfaces;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository repository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public CommandResult Create(string productName, string userCpf)
        {
            var product = _productRepository.GetByName(productName);

            var listProduct = new List<Product>();
            listProduct.Add(product);

            User user = _userRepository.GetByCpf(userCpf);

            if (user == null)
            {
                return new CommandResult(false, "Falha ao realizar o pedido, Usuário não encontrado !", false);
            }

            if (listProduct.FirstOrDefault() == null)
            {
                return new CommandResult(false, "Produto não encontrado !", false);
            }

            var total = listProduct.Select(x => x.Price).Sum();
            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                UserName = user.Name,
                UserCpf = user.CPF,
                ListProducts = listProduct,
                Total = total
            };

            _repository.Create(order);

            return new CommandResult(true, "Ordem cadastrada com sucesso!", order);
        }

        public CommandResult InsertProductOrder(string id, string productName)
        {
            var order = _repository.GetById(id);
            if (order == null)
                return new CommandResult(false, "Falha oa encontrar o Pedido", false);

            var name = productName.ToUpper();
            var products = _productRepository.GetByName(name);
            if (products == null)
                return new CommandResult(false, "Falha oa encontrar o Produto", false);


            order.ListProducts.Add(products);
            order.Total = order.ListProducts.Select(x => x.Price).Sum();

            var result = _repository.Update(id, order);

            return new CommandResult(true, "Lista de produtos atualizada com sucesso!", result);

        }

        public CommandResult RemoveProductOrder(string id, string productName)
        {
            var order = _repository.GetById(id);
            if (order == null)
                return new CommandResult(false, "Falha oa encontrar o Pedido", false);

            var name = productName.ToUpper();
            var product = _productRepository.GetByName(name);
            if (product == null)
                return new CommandResult(false, "Falha oa encontrar o Produto", false);

            var t = order.ListProducts.FirstOrDefault(x => x.Name == productName);
            order.ListProducts.Remove(t);
            order.Total = order.ListProducts.Select(x => x.Price).Sum();

            var result = _repository.Update(id, order);

            return new CommandResult(true, "produto removido com sucesso!", result);

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
            var result = _repository.GetAll();
            if (result.Count == 0)
            {
                return new CommandResult(true, "Não existem pedidos cadastrados no momento!", result);
            }

            return new CommandResult(true, "Pedidos carregados com sucesso!", result);
        }

        public CommandResult GetById(string id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return new CommandResult(false, "Ordem não encontrada !", false);
            }

            return new CommandResult(true, "ordem encontrada com sucesso", result);
        }
    }
}
