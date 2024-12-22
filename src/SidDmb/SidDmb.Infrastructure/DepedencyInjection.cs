using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SidDmb.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {


        return services;
    }
}
