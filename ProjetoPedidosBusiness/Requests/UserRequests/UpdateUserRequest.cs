using MediatR;
using ProjetoPedidosService.Commands;

namespace ProjetoPedidosBusiness.Requests.UserRequests
{
    public class UpdateUserRequest : IRequest<UserCommandResult>
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string CPF { get; set; } = "";
        public string Endereco { get; set; } = "";
    }
}
