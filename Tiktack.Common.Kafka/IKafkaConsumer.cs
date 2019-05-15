using System.Threading.Tasks;

namespace Tiktack.Common.Kafka
{
    public interface IKafkaConsumer
    {
        Task Listen();
    }
}