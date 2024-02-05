using AutoMapper;
using ProjetoPedidosDomain.Dto;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Services
{
    public class CepService : ICepService
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public CepService(IMapper mapper, IApiService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }

        public async Task<GenericResponse<CepModel>> GetEnderecoAsync(string cep)
        {
            var endereco = await _apiService.GetEnderecoAsync(cep);
            return _mapper.Map<GenericResponse<CepModel>>(endereco);
        }
       
    }
}
