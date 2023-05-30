using Acme.BookStore.AdministrationService;
using Acme.BookStore.AdministrationService.EntityFrameworkCore;
using Acme.BookStore.IdentityService;
using Acme.BookStore.IdentityService.EntityFrameworkCore;
using Acme.BookStore.ProductService;
using Acme.BookStore.ProductService.EntityFrameworkCore;
using Acme.BookStore.SaasService;
using Acme.BookStore.SaasService.EntityFrameworkCore;
using Acme.BookStore.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Acme.BookStore.DbMigrator;

[DependsOn(
    typeof(BookStoreSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class BookStoreDbMigratorModule : AbpModule
{

}
