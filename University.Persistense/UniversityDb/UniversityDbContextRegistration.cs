using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace University.Persistence.UniversityDb;

public static class UniversityDbContextRegistration
{

    private const string ConnectionStringName = "UniversityDb";
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString(ConnectionStringName)
                              ?? throw new AggregateException($"Connection string: '{ConnectionStringName}' is not found in configurations.");

        services.AddDbContext<UniversityDbContext>(options =>
        { 
            options.UseNpgsql(
              connectionString,
              npgsqlOptions =>
              {
                  npgsqlOptions.MigrationsHistoryTable(
                        UniversityDbContext.UniversityMigrationHistory,
                        UniversityDbContext.UniversityDbSchema);
              });
        });
    }
}
