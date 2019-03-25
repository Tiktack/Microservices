using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tiktack.Common.Core.IoC
{
    public abstract class Bootstrapper
    {
        public abstract void Configure(IServiceCollection services, IConfiguration configuration);
    }
}
