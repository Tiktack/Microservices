using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace Tiktack.gRPC.Client
{
    /// <summary>
    /// Run this manually in process after gRPC server started in docker(docker compose)
    /// </summary>
    internal class Program
    {
        private static Greeter.GreeterClient _client;
        static async Task Main(string[] args)
        {
            var channel = new Channel("localhost:9988", ChannelCredentials.Insecure);
            _client = new Greeter.GreeterClient(channel);

            await RequestResponse();

            await ServerStreaming();

            await ClientStreaming();

            await BeStreaming();

            Console.ReadKey();
        }

        private static async Task RequestResponse()
        {
            var response = await _client.SayByeAsync(new ByeRequest
            {
                Reps = 3,
                NAME = "Aleh"
            });
            Console.WriteLine(response.Message);
        }

        private static async Task ServerStreaming()
        {
            var call = _client.ServerStreaming(new HelloRequest
            {
                Name = "Aleh"
            });
            var responseStream = call.ResponseStream;

            while (await responseStream.MoveNext())
            {
                var current = responseStream.Current;

                Console.WriteLine(current.Message);
            }
        }

        private static async Task ClientStreaming()
        {
            using (var call = _client.ClientStreaming())
            {
                for (var i = 0; i < 5; i++)
                {
                    await Task.Delay(1000);
                    await call.RequestStream.WriteAsync(new StreamRequest
                    {
                        Message = "Simple message",
                        Count = i
                    });
                }

                await call.RequestStream.CompleteAsync();

                var response = await call.ResponseAsync;

                Console.WriteLine(response.Message);
            }
        }

        private static async Task BeStreaming()
        {
            using (var call = _client.BeStreaming())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var note = call.ResponseStream.Current;
                        Console.WriteLine(note.Message);
                    }
                });

                IEnumerable<StreamRequest> requests = new List<StreamRequest>
                {
                    new StreamRequest
                    {
                        Message = "First message",
                        Count = 1
                    },
                    new StreamRequest
                    {
                        Message = "Second message",
                        Count = 2
                    },
                    new StreamRequest
                    {
                        Message = "Third message",
                        Count = 3
                    }
                };
                foreach (var request in requests)
                {
                    await Task.Delay(1000);
                    Console.WriteLine("Sending request");
                    await call.RequestStream.WriteAsync(request);
                }

                await call.RequestStream.CompleteAsync();
                await responseReaderTask;
            }
        }
    }
}
