namespace ProjetoPedidosDomain.Models
{
    public class Order 
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public User UserName { get; set; } = new ();
        public Product ProductName { get; set; } = new ();
    }
}
