using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto, QueryOptions>, IProductService
    {
        private IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private IProductImageRepository _productImageRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper, IProductImageRepository productImageRepository, ICategoryRepository categoryRepository) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductReadDto> UpdateProductDetailsAsync(Guid productId, ProductUpdateDto updateDto)
        {
            var product = await _productRepository.GetByIdAsync(productId) ?? throw new KeyNotFoundException("Product not found.");
            product.UpdateDetails(updateDto.Name, updateDto.Price, updateDto.Description);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task<ProductReadDto> UpdateProductCategoryAsync(Guid productId, Guid newCategoryId)
        {
            var product = await _productRepository.GetByIdAsync(productId) ?? throw new KeyNotFoundException("Product not found.");
            var category = await _categoryRepository.GetByIdAsync(newCategoryId) ?? throw new KeyNotFoundException("Category not found.");
            product.UpdateCategory(category.Id);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task<ProductReadDto> SetProductImagesAsync(Guid productId, ICollection<ProductImageCreateDto> imageDtos)
        {
            var product = await _productRepository.GetByIdAsync(productId) ?? throw new KeyNotFoundException("Product not found.");
            var images = imageDtos.Select(dto => new ProductImage(productId, dto.Url)).ToList();
            product.SetProductImages(images);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductReadDto>(product);
        }

        public override async Task<ProductReadDto> CreateAsync(ProductCreateDto createDto)
        {
            var product = _mapper.Map<Product>(createDto);

            // var images = new List<ProductImage>();

            // if (createDto.Images != null)
            // {
            //     foreach (var imageUrl in createDto.Images)
            //     {
            //         var productImage = new ProductImage(product.Id, imageUrl);
            //         images.Add(productImage);
            //     }
            // }
            // product.SetProductImages(images);
            await _productRepository.AddAsync(product);
            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return productReadDto;
        }

        public override async Task<ProductReadDto> UpdateAsync(Guid id, ProductUpdateDto updateDto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (!string.IsNullOrEmpty(updateDto.Name))
            {

                product.Name = updateDto.Name;
            }

            if (updateDto.Price.HasValue)
            {

                product.Price = updateDto.Price.Value;
            }

            if (updateDto.CategoryId != null)
            {

                product.CategoryId = updateDto.CategoryId.Value;
            }

            if (updateDto.Images != null && updateDto.Images.Any())
            {
                foreach (var image in updateDto.Images)
                {
                    {
                        var existingImage = await _productImageRepository.CheckImageAsync(image);
                        if (existingImage == false)
                        {
                            var newImage = new ProductImage(productId: product.Id, url: image);
                            await _productImageRepository.AddAsync(newImage);
                        }
                    }
                }
            }

            Console.WriteLine($"Entity after update: {product}");

            var newProduct = await _repository.UpdateAsync(product);
            return _mapper.Map<ProductReadDto>(newProduct);
        }
    }
}
