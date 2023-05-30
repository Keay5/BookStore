// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using Acme.BookStore.ProductService.Products;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Acme.BookStore.ProductService.Products.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IProductPublicAppService), typeof(ProductPublicClientProxy))]
public partial class ProductPublicClientProxy : ClientProxyBase<IProductPublicAppService>, IProductPublicAppService
{
    public virtual async Task<List<ProductDto>> GetListAsync()
    {
        return await RequestAsync<List<ProductDto>>(nameof(GetListAsync));
    }
}
