using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class GetByIdRequest : IRequest<UserCommandResult>
    {
        public string Id { get; set; } = "";
       
    }
}
