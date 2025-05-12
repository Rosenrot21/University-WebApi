using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace University.Application;

public static class ApplicationRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}

