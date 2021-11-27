﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using System;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddRepositories()
                .AddSqlDbContext(configuration);
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<ICoffeeRepository, CoffeeRepository>();

            return services;
        }

        private static IServiceCollection AddSqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlConnectionString");

            return services.AddDbContext<CoffeeContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25))));
        }
    }
}
