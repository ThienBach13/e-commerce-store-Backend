using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IProductService : IBaseService<ProductReadDto, ProductCreateDto, ProductUpdateDto, QueryOptions>
    {
        Task<ProductReadDto> UpdateProductDetailsAsync(Guid productId, ProductUpdateDto updateDto);
        Task<ProductReadDto> UpdateProductCategoryAsync(Guid productId, Guid newCategoryId);
        Task<ProductReadDto> SetProductImagesAsync(Guid productId, ICollection<ProductImageCreateDto> imageDtos);
    }
}