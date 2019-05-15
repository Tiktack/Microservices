using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tiktack.Common.Kafka
{
    public class ConsumerWrapper : IKafkaConsumer
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly IMessageHandler _handler;

        public ConsumerWrapper(IMessageHandler handler)
        {
            _handler = handler;
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "test-group",
                BootstrapServers = "kafka:9092",
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }

        public async Task Listen()
        {
            _consumer.Subscribe("Email");

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };
            try
            {
                while (true)
                {
                    try
                    {
                        var cr = _consumer.Consume(cts.Token);
                        await _handler.HandleMessage(cr);
                        Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                _consumer.Close();
            }
        }
    }
}
