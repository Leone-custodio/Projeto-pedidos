using System.Text.Json.Serialization;

namespace ProjetoPedidosDomain.Dto
{
    public class CepResponse
    {
        public string? Cep { get; set; }

        public string? Estado { get; set; }

        public string? Cidade { get; set; }

        public string? Bairro { get; set; }

        public string? Rua { get; set; }

        [JsonIgnore]
        public string? Service { get; set; }
    }
}
