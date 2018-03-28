using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using SemanticComparison.Fluent;
using Xunit;
using yyyeee.CustomerCatalog.Services;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerGetTests : BaseWebIntegrationTest
    {
        [Fact]
        public async Task should_return_all_customers()
        {
            // Arrange
            var now = DateTimeOffset.Parse("2018-03-28 22:11:34");
            AddCustomerToContext(1, "Test1", 1, now.UtcDateTime);
            AddCustomerToContext(2, "Test2", 2, now.UtcDateTime);
            AddCustomerToContext(3, "Test3", 3, now.UtcDateTime);

            var expected = new List<CustomerDto>
            {
                new CustomerDto(1, "Test1", CustomerStatus.Prospective, now),
                new CustomerDto(2, "Test2", CustomerStatus.Current, now),
                new CustomerDto(3, "Test3", CustomerStatus.NonActive, now)
            };

            // Act
            var actual = await Client.GetStringAsync("/api/customer");

            // Assert
             var actualResult = JsonConvert.DeserializeObject<ICollection<CustomerDto>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }

        private void AddCustomerToContext(int id, string name, int status, DateTime now)
        {
            Context.AddCustomer(new Customer {Id = id, Name = name, Status = status, CreationTime = now});
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