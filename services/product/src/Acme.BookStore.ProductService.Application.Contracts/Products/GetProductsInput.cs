using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.ProductService.Products;

public class GetProductsInput : PagedAndSortedResultRequestDto
{
    public string? FilterText { get; set; }

    public string? Name { get; set; }

    public float? PriceMin { get; set; }

    public float? PriceMax { get; set; }
}
