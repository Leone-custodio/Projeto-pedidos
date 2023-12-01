using MediatR;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class GetByIdRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
       
    }
}
