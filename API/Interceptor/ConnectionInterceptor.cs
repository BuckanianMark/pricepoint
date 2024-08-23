

using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Interceptor
{
    public class ConnectionInterceptor : DbConnectionInterceptor
    {
         private readonly ILogger<ConnectionInterceptor> _logger;

        public ConnectionInterceptor(ILogger<ConnectionInterceptor> logger)
        {
            _logger = logger;
        }
        public override Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("A connection to the database has been established");
            return base.ConnectionOpenedAsync(connection, eventData, cancellationToken);
        }
        public override Task ConnectionFailedAsync(DbConnection connection, ConnectionErrorEventData eventData, CancellationToken cancellationToken = default)
        {
             _logger.LogInformation("Connection to the database failed");
            return base.ConnectionFailedAsync(connection, eventData, cancellationToken);
        }
    }
}