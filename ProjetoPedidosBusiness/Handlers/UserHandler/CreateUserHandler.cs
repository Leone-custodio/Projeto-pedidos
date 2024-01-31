using MediatR;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosBusiness.Handlers.UserHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserCommandResult>
    {
        private readonly IUserService _Service;
        private readonly IEmailService _emailService;

        public CreateUserHandler(IUserService service, IEmailService emailService)
        {
            _Service = service;
            _emailService = emailService;
        }

        public async Task<UserCommandResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                CPF = request.CPF,
                Address = request.Address,
                Password = request.Password,
            };

            var result = _Service.Create(user);

            if (result.Success)
            {
                var email = new EmailModel
                {
                    UserEmail = user.Email,
                    EmailSubject = result.Message,
                    EmailBody = $"{user.Name}, seu cadastro foi criado com sucesso."
                };
                
                await _emailService.SendEmailAsync(email.UserEmail, email.EmailSubject, email.EmailBody);
            }

            return await Task.FromResult(result);
        }

    }
}
