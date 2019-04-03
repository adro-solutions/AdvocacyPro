using AdvocacyPro.Data;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Values;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Services
{
    public static class SeedLogic
    {
        public static async void InitializeDatabase(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await DataInitialization.Seed(context);

                Organization org = await context.Organization.FirstOrDefaultAsync(o => o.Name == "Adro Solutions, LLC");
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                await DataInitialization.SeedAdmin(userManager, roleManager, org.Id);

                DataContext.Initialized = true;
            }
        }
    }
}
