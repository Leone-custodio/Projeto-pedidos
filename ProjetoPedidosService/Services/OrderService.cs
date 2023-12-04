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
            }else if (listProduct.FirstOrDefault() == null)
            {
                return new CommandResult(false, "Produto não encontrado !", false);
            }
            else
            {
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
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public CommandResult GetAll()
        {
            throw new NotImplementedException();
        }

        public CommandResult GetById(string id)
        {
            throw new NotImplementedException();
        }

        public CommandResult Update(string id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
