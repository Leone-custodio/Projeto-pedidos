using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPedidosDomain.Models
{
    [Table("User")]
    public class User
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public string? Id { get; set; }


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
