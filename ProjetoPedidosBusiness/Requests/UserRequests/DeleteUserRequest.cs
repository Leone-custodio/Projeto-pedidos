using MediatR;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class DeleteUserRequest : IRequest<object>
    {
        public string Id { get; set; } = "";
    }
}
