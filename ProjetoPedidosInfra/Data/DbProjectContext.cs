using Microsoft.EntityFrameworkCore;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Data
{
    public class DbProjectContext : DbContext
    {
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
