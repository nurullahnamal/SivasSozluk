
using FluentValidation.AspNetCore;
using SivasSozluk.Api.Application.Extensions;
using SivasSozluk.Api.WebApi.Infrastructure.ActionFilters;
using SivasSozluk.Api.WebApi.Infrastructure.Extensions;
using SivasSozluk.Infrastructure.Persistence.Extensions;

namespace SivasSozluk.Api.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services
            .AddControllers(opt => opt.Filters.Add<ValidateModelStateFilter>())
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .AddFluentValidation()
                .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplicationRegistration();
        builder.Services.AddInfrastructureRegistration(builder.Configuration);
        builder.Services.ConfigureAuth(builder.Configuration);

        // Add Cors
        builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("MyPolicy");

        app.MapControllers();

        app.Run();
    }
}