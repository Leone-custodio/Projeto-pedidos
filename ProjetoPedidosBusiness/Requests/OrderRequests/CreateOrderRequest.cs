using MediatR;
namespace ProjetoPedidosBusiness.Requests.OrderRequests
{
    public class CreateOrderRequest : IRequest<object>
    {
        public string UserName { get; set; } = "";
        public string UserCpf { get; set; } = "";
        public string Product { get; set; } = "";
    }
}
