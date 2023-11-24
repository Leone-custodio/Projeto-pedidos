namespace ProjetoPedidosDomain.Models
{
    public class Product : Identity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
