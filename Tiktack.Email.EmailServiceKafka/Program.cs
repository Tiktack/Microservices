using System;
using System.Threading.Tasks;
using Tiktack.Common.Kafka;

namespace Tiktack.Email.EmailServiceKafka
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await new ConsumerWrapper(new EmailManager()).Listen();
            Console.WriteLine("Service ended listening");
        }
    }
}
