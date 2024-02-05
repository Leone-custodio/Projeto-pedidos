using System.Dynamic;
using System.Net;

namespace ProjetoPedidosDomain.Dto
{
    public class GenericResponse<T> where T : class
    {
        public HttpStatusCode CodigoHtpp { get; set; }
        public T? DadosRetorno { get; set; }
        public ExpandoObject? ErroResponse { get; set; }
    }
}
