using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ChallengeN5.Infrastructure.Context.SqlServer;
using ChallengeN5.Infrastructure.Contracts;
using ChallengeN5.Infrastructure.Repositories;
using ChallengeN5.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ChallengeN5DbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ChallengeN5DbContext")));

            services.AddScoped<IChallengeN5DbContext>(sp =>
                    sp.GetRequiredService<ChallengeN5DbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
                    sp.GetRequiredService<ChallengeN5DbContext>());

            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<PermissionType>, PermissionTypeRepository>();
            services.AddScoped<IRepository<Permission>, PermissionRepository>();

            services.AddSingleton<ProducerService>();
            services.AddSingleton<ConsumerService>();


            return services;
        }
    }

}