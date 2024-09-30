using ClearnArchitecture.Infrastructure.Context.Persistence.MSSQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearnArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            #region SQL Server DB Connection 
            services.AddDbContext<ApplicationMSSQLServer>(options =>
            {
                var connectionString = configuration.GetConnectionString("MSSQLConnection");
                options.UseSqlServer(connectionString);

            });
            #endregion
            return services;

        }
    }
}
