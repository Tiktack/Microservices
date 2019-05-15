using System.Threading.Tasks;
using Confluent.Kafka;
using SendGrid.Helpers.Mail;
using Tiktack.Common.Kafka;
using Tiktack.Email.Core;

namespace Tiktack.Email.EmailServiceKafka
{
    public class EmailManager : IMessageHandler
    {
        private readonly SendGridSender _gridSender = new SendGridSender();
        public async Task HandleMessage(ConsumeResult<Ignore, string> message)
        {
            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress("khantsevitch.oleg@yandex.ru"),
                PlainTextContent = message.Value,
                Subject = "Easy"
            };
            sendGridMessage.AddTo(new EmailAddress("aleh_khantsevich@epam.com"));
            await _gridSender.SendEmail(sendGridMessage);
        }
    }
}
