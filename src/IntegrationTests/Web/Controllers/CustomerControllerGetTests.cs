using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using yyyeee.CustomerCatalog.Services;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerGetTests : BaseIntegrationTest
    {
        [Fact]
        public async Task should_return_all_customers()
        {
            // Arrange
            // TODO
            var expected = new List<CustomerDto>();

            // Act
            var actual = await Client.GetStringAsync("/api/customer");

            // Assert
             var actualResult = JsonConvert.DeserializeObject<ICollection<CustomerDto>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task should_return_empty_collection_when_no_customers()
        {
            // Arrange
            var expected = new List<CustomerDto>();

            // Act
            var actual = await Client.GetStringAsync("/api/customer");

            // Assert
            AssertCollectionOfCustomers(actual, expected);
        }

        private static void AssertCollectionOfCustomers(string actual, ICollection<CustomerDto> expected)
        {
            var actualResult = JsonConvert.DeserializeObject<ICollection<CustomerDto>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }
    }
}