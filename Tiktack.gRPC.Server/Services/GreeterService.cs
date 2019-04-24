using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace Tiktack.gRPC.Server
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<ByeReply> SayBye(ByeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ByeReply
            {
                Message = string.Join(',', Enumerable.Repeat(request.NAME, request.Reps))
            });
        }

        public override async Task ServerStreaming(HelloRequest request,
            IServerStreamWriter<StreamResponse> responseStream,
            ServerCallContext context)
        {
            for (var i = 0; i < 5; i++)
            {
                //writing in response stream in 3s
                await responseStream.WriteAsync(new StreamResponse
                {
                    Message = $"Iteration {i} {request.Name}"
                });
                await Task.Delay(3000);
            }
        }

        public override async Task<HelloReply> ClientStreaming(IAsyncStreamReader<StreamRequest> requestStream,
            ServerCallContext context)
        {
            var list = new List<List<StreamRequest>>();
            while (await requestStream.MoveNext())
            {
                var temp = requestStream.Current;
                list.Add(new List<StreamRequest>(Enumerable.Repeat(temp, temp.Count)));
            }

            return new HelloReply
            {
                Message = string.Join('\n', list.Select(x => string.Join(',', x.Select(y => y.Message))))
            };
        }

        public override async Task BeStreaming(IAsyncStreamReader<StreamRequest> requestStream,
            IServerStreamWriter<StreamResponse> responseStream,
            ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var current = requestStream.Current;
                var responses = ConvertRequestToResponse(current);

                foreach (var response in responses)
                {
                    await responseStream.WriteAsync(response);
                }
            }
        }

        private static IEnumerable<StreamResponse> ConvertRequestToResponse(StreamRequest current)
        {
            for (var i = 0; i < current.Count; i++)
            {
                yield return new StreamResponse
                {
                    Message = current.Message + " Modified"
                };
            }

        }
    }
}
