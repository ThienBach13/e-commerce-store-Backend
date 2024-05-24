using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IProductImageService : IBaseService<ProductImageReadDto, ProductImageCreateDto, ProductImageUpdateDto, QueryOptions>
    {
        Task<ProductImageReadDto> UpdateImageUrlAsync(Guid imageId, string updatedUrl);
    }
}