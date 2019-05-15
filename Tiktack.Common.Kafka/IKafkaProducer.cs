using System.Threading.Tasks;

namespace Tiktack.Common.Kafka
{
    public interface IKafkaProducer
    {
        void Send(string message);
        Task SendAsync(string message);

    }
}