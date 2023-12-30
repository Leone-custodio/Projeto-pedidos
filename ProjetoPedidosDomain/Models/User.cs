using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPedidosDomain.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? Endereco { get; set; }
        public string? Password { get; set;}
    }
}
