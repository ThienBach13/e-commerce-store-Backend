using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.Service;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EcomShop.Tests.src.Service
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task UpdateCategoryImageAsync_ValidCategoryId_ReturnsCategoryReadDtoWithUpdatedImage()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var updatedImage = "new-image-url";
            var categoryToUpdate = new Category("Category Name", "Old Image");
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(categoryId)).ReturnsAsync(categoryToUpdate);
            categoryRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Category>())).ReturnsAsync(categoryToUpdate); // Mocking the UpdateAsync method
            mapperMock.Setup(mapper => mapper.Map<CategoryReadDto>(It.IsAny<Category>()))
                      .Returns<Category>(category => new CategoryReadDto { Id = category.Id, Name = category.Name, Image = updatedImage }); // Corrected property name to "Image"
            var categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await categoryService.UpdateCategoryImageAsync(categoryId, updatedImage);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryReadDto>(result);
            Assert.Equal(updatedImage, result.Image); // Corrected property name to "Image"
        }

        [Fact]
        public async Task UpdateCategoryNameAsync_ValidCategoryId_ReturnsCategoryReadDtoWithUpdatedName()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var updatedName = "New Category Name";
            var categoryToUpdate = new Category("Category Name", "Old Image");
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(categoryId)).ReturnsAsync(categoryToUpdate);
            categoryRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Category>())).ReturnsAsync(categoryToUpdate); // Mocking the UpdateAsync method
            mapperMock.Setup(mapper => mapper.Map<CategoryReadDto>(It.IsAny<Category>()))
                      .Returns<Category>(category => new CategoryReadDto { Id = category.Id, Name = updatedName, Image = category.Image }); // Corrected property name to "Image"
            var categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await categoryService.UpdateCategoryNameAsync(categoryId, updatedName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryReadDto>(result);
            Assert.Equal(updatedName, result.Name);
        }

    }
}
