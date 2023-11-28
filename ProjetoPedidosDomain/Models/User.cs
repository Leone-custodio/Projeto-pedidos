using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPedidosDomain.Models
{
    public class User
    {
        [Column("ID")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public string? CPF { get; set; }
    }
}
