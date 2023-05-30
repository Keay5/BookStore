using Acme.BookStore.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
