using ClearnArchitecture.Domain.IRepositories;
using ClearnArchitecture.Infrastructure.Context.Persistence.MSSQLServer;
using ClearnArchitecture.Infrastructure.Repositories;
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

            #region PostgreSql DB Connection 
            services.AddDbContext<ApplicationMSSQLServer>(options =>
            {
                var connectionString = configuration.GetConnectionString("PostgreSqlConnection");
                options.UseNpgsql(connectionString);

            });
            #endregion

            #region Inject Repositories 
            services.AddScoped<IStudentRepository, StudentRepository>();
            #endregion
            return services;

        }
    }
}
