using CrudTest.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CrudTest.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton<ProblemDetailsFactory, CrudTestProblemDetailsFactory>();

        return services;
    }
}
