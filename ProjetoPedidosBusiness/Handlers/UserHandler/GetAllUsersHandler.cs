using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, object>
    {
        private readonly IUserService _Service;

        public GetAllUsersHandler(IUserService service)
        {
            _Service = service;
        }

        public async Task<object> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var result = _Service.GetAll();
            return await Task.FromResult(result);
        }
    }
}
