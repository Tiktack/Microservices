using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNet.OData.Extensions;
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
                    "Pitstop"));
            services.AddTransient<IUnitOfWork, UnitOfWorkBase>();
            services.AddHealthChecks();
            services.AddOData();
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
