namespace ProjetoPedidosDomain.Models
{
    public class Order 
    {
        public string Id { get; set; } = "";
        public DateTime CreatedDate { get; set; } 
        public string UserName { get; set; } = "";
        public string UserCpf { get; set; } = "";
        public List<Product> ListProducts { get; set; } = new ();
        public decimal Total { get; set; }
    }
}
