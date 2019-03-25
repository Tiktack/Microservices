using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Tiktack.Common.Messaging;
using Tiktack.Email.Core;

namespace Tiktack.Email.EmailService
{
    public class EmailManager : IMessageHandlerCallback
    {
        private readonly IMessageHandler _messageHandler;

        public EmailManager(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;

        }
        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }
        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            switch (messageType)
            {
                case "1":
                    {
                        await HandleOne(message);
                        break;
                    }
                case "2":
                    {
                        await HandleTwo(message);
                        break;
                    }
                default: return false;
            }
            return true;
        }

        private async Task HandleOne(string message)
        {
            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress("khantsevitch.oleg@yandex.ru"),
                PlainTextContent = message,
                Subject = "Easy"
            };
            sendGridMessage.AddTo(new EmailAddress("aleh_khantsevich@epam.com"));
            await new SendGridSender().SendEmail(sendGridMessage);
        }
        private async Task HandleTwo(string message)
        {
            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress("khantsevitch.oleg@yandex.ru"),
                PlainTextContent = message,
                Subject = "Easy 2"
            };
            sendGridMessage.AddTo(new EmailAddress("aleh_khantsevich@epam.com"));
            await new SendGridSender().SendEmail(sendGridMessage);
        }
    }
}
