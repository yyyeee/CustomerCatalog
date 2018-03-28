using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
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
            var actual = await InvokeAddCustomerMethod(command);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.Created);
            var actualCustomer = Context.GetCustomer(command.Id);
            actualCustomer.Should().BeEquivalentTo(expected);
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
            var actual = await InvokeAddCustomerMethod(command);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }

        private async Task<HttpResponseMessage> InvokeAddCustomerMethod(AddCustomerCommand command)
        {
            var result =
                await Client.PostAsync("/api/customer", new StringContent(JsonConvert.SerializeObject(command)));
            return result;
        }
    }
}