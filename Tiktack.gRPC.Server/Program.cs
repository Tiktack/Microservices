using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace Tiktack.gRPC.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                        {
                            options.Limits.MinRequestBodyDataRate = null;
                            options.ListenAnyIP(9988, listenOptions =>
                            {
                                listenOptions.Protocols = HttpProtocols.Http2;
                            });
                        })
                        .UseStartup<Startup>();
                });
    }
}
