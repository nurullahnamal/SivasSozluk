using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SivasSozluk.Api.Application.Interfaces.Repositories;
using SivasSozluk.Infrastructure.Persistence.Context;
using SivasSozluk.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivasSozluk.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SivasSozlukContext>(conf =>
        {
            var connStr = configuration["SivasSozlukDbConnectionString"].ToString();
            conf.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();

        return services;


    }
}