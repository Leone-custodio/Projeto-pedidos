using ProjetoPedidosDomain.Dto;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosService.Interfaces
{
    public interface ICepService
    {
        Task<GenericResponse<CepModel>> GetEnderecoAsync(string cep);
    }
}
