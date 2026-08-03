using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KickBase.Api;

public static class KickBaseApiExtensions
{
    public static IServiceCollection AddKickBaseApi(this IServiceCollection services)
    {
        
        services.AddHttpClient<IKickBaseApiClient, KickBaseApiClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<KickBaseApiOptions>>().Value;
            client.BaseAddress = options.BaseUrl;
        });

        return services;
    }
}