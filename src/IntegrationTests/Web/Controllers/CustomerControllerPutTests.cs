using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.CustomerWrite;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerPutTests : BaseWebIntegrationTest
    {
        [Fact]
        public async Task should_update_customer()
        {
            // Arrange
            var id = Guid.NewGuid();
            Context.AddCustomer(new Customer { Id = id, Name = "old name", Status = 1, CreationTime = DateTime.Now });
            var command = new UpdateCustomerCommand
            {
                Name = "New name",
                Status = CustomerStatus.Current,
                Id = id
            };
            var expected = new Customer
            {
                Id = id,
                Name = command.Name,
                Status = 2
            };

            // Act
            var actual = await InvokeUpdateCustomerMethod(command);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
            var actualCustomer = Context.GetCustomer(id);
            actualCustomer.Should().BeEquivalentTo(expected, opts => opts.Excluding(c => c.CreationTime));
        }
        
        private async Task<HttpResponseMessage> InvokeUpdateCustomerMethod(UpdateCustomerCommand command)
        {
            var result =
                await Client.PutAsync("/api/customer", 
                    new StringContent(
                        JsonConvert.SerializeObject(command),
                        Encoding.UTF8,
                        "application/json"));
            return result;
        }
    }
}