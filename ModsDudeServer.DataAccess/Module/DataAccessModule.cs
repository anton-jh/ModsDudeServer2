using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.Module;
public static class DataAccessModule
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString, bool isDevelopment)
    {
        services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlServer(connectionString);

            if (isDevelopment)
            {
                builder
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine);
            }
        });

        return services;
    }
}
