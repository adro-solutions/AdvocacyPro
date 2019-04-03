using AdvocacyPro.Data;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdvocacyPro.Services.Extensions
{
    public static class Identity
    {
        public static void AddCSPIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<DataContext>()
               .AddDefaultTokenProviders();
        }
    }
}
