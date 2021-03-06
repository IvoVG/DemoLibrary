using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoLibrary.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        const string AdministratorRoleName = "Administrator";

        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope= app.ApplicationServices.CreateScope();
            var services=serviceScope.ServiceProvider;

            MigrateDatabase(services);
            //SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<LibraryDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@library.com";
                    const string adminPassword = "Admin123";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
