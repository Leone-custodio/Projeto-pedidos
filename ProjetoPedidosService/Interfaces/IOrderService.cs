﻿using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosService.Interfaces
{
    public interface IOrderService
    {
        Task<User> Create(User user);
        Task<User> GetById(Guid id);
        Task<User> GetAll();
        Task<User> Update(Guid id);
        Task<User> Delete(Guid id);
    }
}
