using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Tiktack.Email.Core
{
    public class SendGridSender
    {
        private readonly SendGridClient _client;

        public SendGridSender() => _client = new SendGridClient("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");
        public SendGridSender(string apiKey) => _client = new SendGridClient(apiKey);

        public SendGridSender(SendGridClientOptions options) => _client = new SendGridClient(options);

        public async Task<Response> SendEmail(SendGridMessage message)
        {
            return await _client.SendEmailAsync(message);
        }
    }
}
