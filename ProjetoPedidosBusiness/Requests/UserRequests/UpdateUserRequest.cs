using MediatR;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class UpdateUserRequest : IRequest<Object>
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string CPF { get; set; } = "";
    }
}
