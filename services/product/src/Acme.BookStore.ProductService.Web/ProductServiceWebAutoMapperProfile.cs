using AutoMapper;
using Acme.BookStore.ProductService.Products;

namespace Acme.BookStore.ProductService.Web;

public class ProductServiceWebAutoMapperProfile : Profile
{
    public ProductServiceWebAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>();
    }
}
