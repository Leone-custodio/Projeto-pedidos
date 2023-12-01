using MongoDB.Driver;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Data
{
    public class DbProjectContext 
    {
        public static string ConnectionString { get; set; } = "";
        public static string DatabaseName { get; set; } = "";
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get;}

        public DbProjectContext()
        {
            try
            {
                MongoClientSettings setting = MongoClientSettings
                    .FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    setting.SslSettings = new SslSettings 
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }

                var mongoClient = new MongoClient(setting);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao conectar ao banco");
            }
        }

        public IMongoCollection<User> Users 
        {
            get 
            {
                return _database.GetCollection<User>("User");
            }
        }

        public IMongoCollection<Product> Products
        {
            get 
            {
                return _database.GetCollection<Product>("Product");
            }
        }

        public IMongoCollection<Order> Orders
        {
            get 
            {
                return _database.GetCollection<Order>("Order");
            }
        }
    }
}
