using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
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
            var expected = new List<CustomerDto>
            {
                CreateAndReturnExpectedCustomer(1, CustomerStatus.Prospective),
                CreateAndReturnExpectedCustomer(2, CustomerStatus.Current),
                CreateAndReturnExpectedCustomer(3, CustomerStatus.NonActive),
            };

            // Act
            var actual = await Client.GetStringAsync("/api/customer");

            // Assert
             var actualResult = JsonConvert.DeserializeObject<ICollection<CustomerDto>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }

        private CustomerDto CreateAndReturnExpectedCustomer(int statusValue, CustomerStatus expectedStatus)
        {
            var id = Guid.NewGuid();
            var name = $"Test{id}";
            var date = DateTimeOffset.Parse("2018-03-28 22:11:34");
            AddCustomerToContext(id, name, statusValue, date.UtcDateTime);
            return new CustomerDto(id, name, expectedStatus, date);
        }

        private void AddCustomerToContext(Guid id, string name, int status, DateTime now)
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