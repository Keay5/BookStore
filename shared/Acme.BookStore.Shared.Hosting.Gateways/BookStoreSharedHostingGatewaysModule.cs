using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Acme.BookStore.Shared.Hosting.AspNetCore;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Polly;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Acme.BookStore.Shared.Hosting.Gateways;

[DependsOn(
    typeof(BookStoreSharedHostingAspNetCoreModule),    
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpSwashbuckleModule)
)]
public class BookStoreSharedHostingGatewaysModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var env = context.Services.GetHostingEnvironment();

        var ocelotBuilder = context.Services.AddOcelot(configuration)
            .AddPolly();

        if (!env.IsProduction())
        {
            ocelotBuilder.AddDelegatingHandler<AbpRemoveCsrfCookieHandler>(true);
        }
    }
}
