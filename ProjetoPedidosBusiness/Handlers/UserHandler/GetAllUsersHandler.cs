using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
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

        //public async Task<List<object>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        //{
        //    var list = new List<object>();
        //    var result = _Service.GetAll();

        //    foreach (var item in result) 
        //    {
        //        list.Add(item);
        //    }
        //    return await Task.FromResult(list);
        //}
    }
}
