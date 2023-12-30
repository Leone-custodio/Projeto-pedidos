using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosService.Interfaces
{
    public interface IProductCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
