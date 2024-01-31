using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class GetByCpfRequest : IRequest<UserCommandResult>
    {
        public string Cpf { get; set; } = "";
       
    }
}
