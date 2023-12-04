﻿using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosService.Interfaces
{
    public interface IProductService
    {
        CommandResult Create(Product product);
        CommandResult GetById(string id);
        CommandResult GetAll();
        Product Update(string id, Product product);
        CommandResult Delete(string id);
    }
}
