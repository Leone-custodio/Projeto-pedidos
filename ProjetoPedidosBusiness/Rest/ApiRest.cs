using ProjetoPedidosDomain.Dto;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;
using System.Dynamic;
using System.Text.Json;

namespace ProjetoPedidosBusiness.Rest
{
    public class ApiRest : IApiService
    {
        public async Task<GenericResponse<CepModel>> GetEnderecoAsync(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var response = new GenericResponse<CepModel>();

            using (var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();
                var objResp = JsonSerializer.Deserialize<CepModel>(contentResp);

                if (responseApi.IsSuccessStatusCode)
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.DadosRetorno = objResp;
                }
                else
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.ErroResponse = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }
    }
}
