using AutoMapper;
using ProjetoPedidosDomain.Dto;
using ProjetoPedidosDomain.Models;

namespace ProjetoPedidosInfra.Mapping
{
    public class EnderecoMaping : Profile
    {
        public EnderecoMaping()
        {
            CreateMap(typeof(GenericResponse<CepModel>), typeof(GenericResponse<CepModel>));
        }
    }
}
