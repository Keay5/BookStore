using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Acme.BookStore.ProductService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductServiceDomainSharedModule)
)]
public class ProductServiceDomainModule : AbpModule
{

}
