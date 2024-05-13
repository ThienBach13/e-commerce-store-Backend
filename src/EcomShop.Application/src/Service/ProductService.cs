using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class ProductService : IProductService
    {
        private readonly IProduct _productRepository;

        public ProductService(IProduct productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto product)
        {
            var productEntity = ProductCreateDto.CreateProduct(product);
            var createdProduct = await _productRepository.CreateProductAsync(productEntity);
            var createdProductDto = new ProductReadDto();
            createdProductDto.Transform(createdProduct);
            return createdProductDto;
        }
        public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsync(ProductQueryOptions queryOptions)
        {
            var products = await _productRepository.GetAllProductsAsync(queryOptions);
            return ProductReadDto.ConvertList(products);
        }

        public async Task<ProductReadDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            var productDto = new ProductReadDto();
            productDto.Transform(product);
            return productDto;
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByPaginationAsync(int offset, int limit)
        {
            var products = await _productRepository.GetProductsByPaginationAsync(offset, limit);
            return ProductReadDto.ConvertList(products);
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByPriceRangeAsync(decimal priceMin, decimal priceMax)
        {
            var products = await _productRepository.GetProductsByPriceRangeAsync(priceMin, priceMax);
            return ProductReadDto.ConvertList(products);
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoriesAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoriesAsync(categoryId);
            return ProductReadDto.ConvertList(products);
        }

        public async Task<IEnumerable<ProductReadDto>> SearchProductsByNameAsync(string searchKey)
        {
            var products = await _productRepository.SearchProductsByNameAsync(searchKey);
            return ProductReadDto.ConvertList(products);
        }

        public async Task<IEnumerable<ProductReadDto>> SortProductsByPriceAsync(string sortOrder)
        {
            var products = await _productRepository.SortProductsByPriceAsync(sortOrder);
            return ProductReadDto.ConvertList(products);
        }

        public async Task<IEnumerable<ProductReadDto>> SortProductsByNameAsync(string sortOrder)
        {
            var products = await _productRepository.SortProductsByPriceAsync(sortOrder);
            return ProductReadDto.ConvertList(products);
        }
        public async Task<bool> UpdateProductByIdAsync(ProductUpdateDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productDto.Id);
            if (existingProduct == null)
                return false;

            existingProduct = productDto.UpdateProduct(existingProduct);
            return await _productRepository.UpdateProductByIdAsync(existingProduct);
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            return await _productRepository.DeleteProductByIdAsync(id);
        }
    }
}
