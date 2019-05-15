using Confluent.Kafka;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tiktack.Common.Kafka
{
    public class ProducerWrapper : IKafkaProducer
    {

        private readonly IProducer<Null, string> _producer;

        private readonly Action<DeliveryReport<Null, string>> _handler = r =>
            Console.WriteLine(!r.Error.IsError
                ? $"Delivered message to {r.TopicPartitionOffset}"
                : $"Delivery Error: {r.Error.Reason}");

        public ProducerWrapper()
        {
            _producer = new ProducerBuilder<Null, string>(new ProducerConfig
            {
                BootstrapServers = "kafka:9092"
            }).Build();
        }

        public void Send(string message)
        {
            _producer.Produce("Email", new Message<Null, string>
            {
                Value = message
            }, _handler);

            _producer.Flush();
        }

        public async Task SendAsync(string message)
        {
            try
            {
                await _producer.ProduceAsync("NewTest", new Message<Null, string>
                {
                    Value = "test string"
                });
            }
            catch (ProduceException<Null, string> e)
            {
                Debug.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}
