using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosService.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(string name, string email, string cpf);
        Task<User> GetById(Guid id);
        Task<User> GetAll();
        Task<User> Update(Guid id);
        Task<User> Delete(Guid id);
    }
}
