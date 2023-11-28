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

        public Task<User> Create(string name, string email, string cpf)
        {
            var user = new User 
            { 
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CPF = cpf
            };

            _context.Users.InsertOne(user);

            return Task.FromResult(user);

        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
