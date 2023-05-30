using Acme.BookStore.SaasService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.BookStore.SaasService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SaasServiceEntityFrameworkCoreTestModule)
    )]
public class SaasServiceDomainTestModule : AbpModule
{

}
