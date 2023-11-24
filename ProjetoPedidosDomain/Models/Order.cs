namespace ProjetoPedidosDomain.Models
{
    public class Order : Identity
    {
        public DateTime CreatedDate { get; set; } 
        public User UserName { get; set; } = new ();
        public Product ProductName { get; set; } = new ();
    }
}
