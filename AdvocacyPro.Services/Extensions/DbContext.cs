using AdvocacyPro.Data;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Values;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdvocacyPro.Services.Extensions
{
    public static class DbContext
    {
        public static void AddCSPDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
