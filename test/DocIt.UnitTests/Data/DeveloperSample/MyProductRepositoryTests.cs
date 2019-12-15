using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Moq;
using DocIt.Configurations.DeveloperSample;
using DocIt.Data.DeveloperSample;
using DocIt.Models.DeveloperSample;
using Xunit;

namespace DocIt.UnitTests.Data.DeveloperSample
{
    public class MyProductRepositoryTests
    {
        [Fact]
        public void ProductRepository_GetAllAsync_ReturnsSomeProducts()
        {
            var optionsMock = new Mock<IOptions<ServiceDependenciesConfig>>();
            IMyProductRepository productRepository = new MyProductRepository(null, optionsMock.Object);

            IEnumerable<MyProduct> products = productRepository.GetAllAsync().Result;

            Assert.NotEmpty(products);
        }

        [Theory]
        [InlineData("AAA-001")]
        [InlineData("AAA-002")]
        [InlineData("AAA-003")]
        public void ProductRepository_GetAsync_ReturnsRequestedProduct(string productName)
        {
            var optionsMock = new Mock<IOptions<ServiceDependenciesConfig>>();
            IMyProductRepository productRepository = new MyProductRepository(null, optionsMock.Object);

            MyProduct product = productRepository.GetAsync(productName).Result;

            Assert.Equal(product.MyProductId, productName);
        }
    }
}
