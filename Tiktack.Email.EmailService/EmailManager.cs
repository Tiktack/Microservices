using System;
using System.Threading.Tasks;
using Tiktack.Common.Messaging;

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
            Console.WriteLine("MESSAGE HANDLED SUCSECC !!!");
            await Task.Delay(10);
            return true;
        }
    }
}
