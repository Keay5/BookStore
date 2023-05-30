using AutoMapper;
using Acme.BookStore.ProductService.Products;

namespace Acme.BookStore.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
