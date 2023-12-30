using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Commands
{
    public class OrderCommandResult : IOrderCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static OrderResult Result(bool success, string? message,Order? order)
        {
            return new OrderResult {  Success = success, Message = message, Order = order };
        }

        public static OrderListResult ResultList(bool success, string? message,List<Order>? orders)
        {
            return new OrderListResult {  Success = success, Message = message, Orders = orders };
        }
    }
    public class OrderResult : OrderCommandResult
    {
        public Order? Order { get; set; }
    }

    public class OrderListResult : OrderCommandResult
    {
        public List<Order>? Orders { get; set; }
    }
}
