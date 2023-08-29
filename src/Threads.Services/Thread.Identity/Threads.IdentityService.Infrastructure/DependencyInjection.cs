using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Threads.BuildingBlock.Application.Persistences;
using Threads.BuildingBlock.Infrastructure.Repositories;
using Threads.IdentityService.Domain.Entities;
using Threads.IdentityService.Infrastructure.Persistence;

namespace Threads.IdentityService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(
                        options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<DbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationIdentityDbContext>());

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddScoped(typeof(ISqlRepository<>), typeof(EfRepository<>));
            return services;
        }
    }
}
