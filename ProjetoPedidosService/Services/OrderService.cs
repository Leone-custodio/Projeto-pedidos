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

        public OrderCommandResult Create(string productId, string userCpf)
        {
            var product = _productRepository.GetById(productId);

            var listProduct = new List<Product>();
            listProduct.Add(product);

            User user = _userRepository.GetByCpf(userCpf);

            if (user == null)
            {
                return OrderCommandResult.Result(false, "Falha ao realizar o pedido, Usuário não encontrado !", null);
            }

            if (listProduct.FirstOrDefault() == null)
            {
                return OrderCommandResult.Result(false, "Falha ao realizar o pedido, Produto não encontrado !", null);
            }

            var total = listProduct.Select(x => x.Price).Sum();
            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow,
                UserName = user.Name,
                UserCpf = user.CPF,
                ListProducts = listProduct,
                Total = total
            };

            _repository.Create(order);

            return OrderCommandResult.Result(true, "Ordem cadastrada com sucesso!", order);
        }

        public OrderCommandResult InsertProductOrder(string id, string productId)
        {
            var order = _repository.GetById(id);
            if (order == null)
                return OrderCommandResult.Result(false, "Falha oa encontrar o Pedido", null);

            var products = _productRepository.GetById(productId);
            if (products == null)
                return OrderCommandResult.Result(false, "Falha oa encontrar o Produto", null);

            order.ListProducts.Add(products);
            order.Total = order.ListProducts.Select(x => x.Price).Sum();

            var result = _repository.Update(id, order);

            return OrderCommandResult.Result(true, "Lista de produtos atualizada com sucesso!", result);
        }

        public OrderCommandResult RemoveProductOrder(string id, string productId)
        {
            var order = _repository.GetById(id);
            if (order == null)
                return OrderCommandResult.Result(false, "Falha oa encontrar o Pedido", null);

            var product = _productRepository.GetById(productId);
            if (product == null)
                return OrderCommandResult.Result(false, "Falha oa encontrar o Produto", null);

            var t = order.ListProducts.FirstOrDefault(x => x.Id == productId);
            if (t != null)
            {
                order.ListProducts.Remove(t);
            }

            order.Total = order.ListProducts.Select(x => x.Price).Sum();

            var result = _repository.Update(id, order);

            return OrderCommandResult.Result(true, "produto removido com sucesso!", result);

        }

        public OrderCommandResult Delete(string id)
        {
            var delete = _repository.GetById(id);
            if (delete == null)
            {
                return OrderCommandResult.Result(false, $"Não existi um cadastro para id {id} no sistema !", null);
            }

            _repository.Delete(id);
            return  OrderCommandResult.Result(true, "Produto excluido com sucesso !", delete);
        }

        public OrderCommandResult GetAll()
        {
            var result = _repository.GetAll();
            if (result.Count == 0)
            {
                return OrderCommandResult.ResultList(true, "Não existem pedidos cadastrados no momento!", result);
            }

            return OrderCommandResult.ResultList(true, "Pedidos carregados com sucesso!", result);
        }

        public OrderCommandResult GetById(string id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return OrderCommandResult.Result(false, "Ordem não encontrada !", null);
            }

            return OrderCommandResult.Result(true, "ordem encontrada com sucesso", result);
        }

        public OrderCommandResult GetByUserCpf(string userCpf)
        {
            var result = _repository.GetByUserCpf(userCpf);
            if (result.Count == 0)
            {
                return OrderCommandResult.Result(false, "Não existem pedidos para este cpf", null);
            }

            return OrderCommandResult.ResultList(true, "Pedidos encontrados com sucesso", result);
        }
    }
}
