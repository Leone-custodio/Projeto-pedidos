using SendGrid.Helpers.Mail;
using SendGrid;
using ProjetoPedidosService.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ProjetoPedidosService.Services
{
    public class EmailService : IEmailService
    {

        private readonly string _apiKey;
        private readonly string _senderEmail;

        public EmailService(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:API_KEY_SENDGRID"];
            _senderEmail = configuration["SendGrid:SENDER_EMAIL"];
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_senderEmail, "Pedidos Market");

            var message = MailHelper.CreateSingleEmail(from, new EmailAddress(to), subject, body, body);

            var response = await client.SendEmailAsync(message);

        }

    }
}
