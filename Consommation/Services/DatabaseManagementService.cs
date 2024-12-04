using Consommation.Database;
using Microsoft.EntityFrameworkCore;

namespace Consommation.API.Services;

public class DatabaseManagementService
{
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<DatabaseContext>().Database.Migrate();
        }
    }
}