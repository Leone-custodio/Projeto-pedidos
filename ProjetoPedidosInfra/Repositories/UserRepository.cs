using MongoDB.Driver;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Data;
using ProjetoPedidosInfra.Interfaces;

namespace ProjetoPedidosInfra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbProjectContext _context;

        public UserRepository(DbProjectContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.InsertOne(user);
            return user;
        }

        public void Delete(string id)
        {
            _context.Users.FindOneAndDelete(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            var users = _context.Users.Find(x => true).ToList();
            return users;
        }

        public User GetById(string id)
        {
            var user = _context.Users.Find(x => x.Id == id).FirstOrDefault();
            return user;
        }
        
        public User GetByCpf(string? cpf)
        {
            User user = _context.Users.Find(x => x.CPF == cpf).FirstOrDefault();
            return user;
        }

        public User Update(string? id, User user)
        {
            _context.Users.ReplaceOne(x => x.Id == id, user);
            return user;
        }
    }
}
