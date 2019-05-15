using System.Threading.Tasks;
using Confluent.Kafka;

namespace Tiktack.Common.Kafka
{
    /// <summary>
    /// Implement this interface in ur consumer service
    /// </summary>
    public interface IMessageHandler
    {
        Task HandleMessage(ConsumeResult<Ignore, string> message);
    }
}
