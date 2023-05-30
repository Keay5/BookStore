using Acme.BookStore.SaasService.Application;
using Volo.Abp.Modularity;

namespace Acme.BookStore.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
