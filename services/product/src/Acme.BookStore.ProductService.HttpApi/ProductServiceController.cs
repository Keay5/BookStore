using Acme.BookStore.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
