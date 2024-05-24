using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class ProductImageService : BaseService<ProductImage, ProductImageReadDto, ProductImageCreateDto, ProductImageUpdateDto, QueryOptions>, IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository, IMapper mapper)
            : base(productImageRepository, mapper)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<ProductImageReadDto> UpdateImageUrlAsync(Guid imageId, string updatedUrl)
        {
            var productImage = await _productImageRepository.GetByIdAsync(imageId);
            productImage.UpdateUrl(updatedUrl);
            await _productImageRepository.UpdateAsync(productImage);
            return _mapper.Map<ProductImageReadDto>(productImage);
        }
    }
}