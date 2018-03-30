using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using yyyeee.CustomerCatalog.Services.CustomerWrite;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerPostTests : BaseWebIntegrationTest
    {
        [Fact]
        public async Task should_add_customer()
        {
            // Arrange
            var command = new AddCustomerCommand
            {
                Name = "Test Customer",
                Id = Guid.NewGuid()
            };
            var expected = new Customer
            {
                Id = command.Id,
                Name = command.Name,
                Status = 1
            };

            // Act
            var actual = await InvokePost("/api/customer",command);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.Created);
            var actualCustomer = Context.GetCustomer(command.Id);
            actualCustomer.Should().BeEquivalentTo(expected, opts => opts.Excluding(c => c.CreationTime));
        }

        [Fact]
        public async Task should_return_409_response_when_duplicated_id()
        {
            // Arrange
            var duplicatedGuid = Guid.NewGuid();
            Context.AddCustomer(new Customer {Id = duplicatedGuid});
            var command = new AddCustomerCommand
            {
                Name = "Test Customer",
                Id = duplicatedGuid
            };

            // Act
            var actual = await InvokePost("/api/customer", command);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}