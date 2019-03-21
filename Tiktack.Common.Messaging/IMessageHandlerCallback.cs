using System.Threading.Tasks;

namespace Tiktack.Common.Messaging
{
    public interface IMessageHandlerCallback
    {
        Task<bool> HandleMessageAsync(string messageType, string message);
    }
}
