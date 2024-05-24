using System;
using System.Threading.Tasks;
using EcomShop.Application.src.Service;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using EcomShop.Core.src.ValueObject;

using Moq;
using Xunit;

namespace EcomShop.Tests.src.Service
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUserByUserEmail_ValidEmail_ReturnsUser()
        {
            // Arrange
            var userEmail = "test@example.com";
            var user = new User { Id = Guid.NewGuid(), Email = userEmail, Password = "password", Role = Role.Customer };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUserByEmailAsync(userEmail)).ReturnsAsync(user);

            var userService = new UserService(userRepositoryMock.Object, null);

            // Act
            var result = await userService.GetUserByUserEmail(userEmail);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userEmail, result.Email);
        }

        [Fact]
        public async Task GetUserByUserEmail_InvalidEmail_ReturnsNull()
        {
            // Arrange
            var userEmail = "nonexistent@example.com";

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUserByEmailAsync(userEmail)).ReturnsAsync((User)null);

            var userService = new UserService(userRepositoryMock.Object, null);

            // Act
            var result = await userService.GetUserByUserEmail(userEmail);

            // Assert
            Assert.Null(result);
        }
    }
}
