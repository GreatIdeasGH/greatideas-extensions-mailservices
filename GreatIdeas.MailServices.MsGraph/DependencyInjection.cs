using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.TokenCacheProviders.InMemory;

namespace GreatIdeas.MailServices.MsGraph;

public static class DependencyInjection
{
    /// <summary>
    /// Add DI for <see cref="MsGraphService"/> with configuration
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddMsGraphMailService(this IServiceCollection services, IConfiguration configuration)
    {
        // Azure Storage Settings
        services.Configure<AzureAdOptions>(configuration.GetSection("AzureAd"));

        // Register MsGraphMailService
        services.AddTransient<IMsGraphService, MsGraphService>();

        // Register Microsoft Graph
        services
            .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"))
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(configuration.GetSection("Graph"))
            .AddInMemoryTokenCaches();

        return services;
    }

}
