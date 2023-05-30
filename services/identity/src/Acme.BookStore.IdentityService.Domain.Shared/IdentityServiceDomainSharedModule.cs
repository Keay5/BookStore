﻿using Acme.BookStore.IdentityService.Localization;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Acme.BookStore.IdentityService;

[DependsOn(
    typeof(AbpIdentityProDomainSharedModule),
    typeof(AbpOpenIddictProDomainSharedModule)
)]
public class IdentityServiceDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        IdentityServiceModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<IdentityServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/IdentityService");
        });

    }
}
