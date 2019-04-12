using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using Tiktack.Common.Messaging;
using Tiktack.Web.DataLayer;

namespace Tiktack.Web.Api
{
    public class Bootstrapper : Common.Core.IoC.Bootstrapper
    {
        public override void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var (host, userName, password) = GetOptionsForRabbitM(configuration);

            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
            services.AddTransient<IMessagePublisher>(sp =>
                new RabbitMQMessagePublisher(host, userName, password,
                    "Email"));
            services.AddTransient<IUnitOfWork, UnitOfWorkBase>();
            services.AddHealthChecks();
            services.AddOData();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static Tuple<string, string, string> GetOptionsForRabbitM(IConfiguration configuration)
        {
            var configSection = configuration.GetSection("RabbitMQ");
            var host = configSection["Host"];
            var userName = configSection["UserName"];
            var password = configSection["Password"];

            return new Tuple<string, string, string>(host, userName, password);
        }
    }
}
