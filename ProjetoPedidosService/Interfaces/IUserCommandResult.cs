namespace ProjetoPedidosService.Interfaces
{
    public interface IUserCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
