using ProjetoPedidosDomain.Dto;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosService.Interfaces
{
    public interface IApiService
    {
        Task<GenericResponse<CepModel>> GetEnderecoAsync(string cep);
    }
}
