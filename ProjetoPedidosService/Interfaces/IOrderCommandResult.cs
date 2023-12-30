namespace ProjetoPedidosService.Interfaces
{
    public interface IOrderCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
