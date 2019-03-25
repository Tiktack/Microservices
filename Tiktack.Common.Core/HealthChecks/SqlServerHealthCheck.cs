using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Tiktack.Common.Core.HealthChecks
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly SqlConnection _connection;

        public string Name => "sql";

        public SqlServerHealthCheck(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _connection.OpenAsync(cancellationToken);
            }
            catch (SqlException)
            {
                return HealthCheckResult.Unhealthy();
            }
            return HealthCheckResult.Healthy();
        }
    }
}
