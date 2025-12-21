using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Abstractions;
using Portfolio.Infrastructure.Persistence;
using Portfolio.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<ISkillRepository, SkillRepository>();

        return services;
    }
}
