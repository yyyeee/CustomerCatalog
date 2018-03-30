using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using yyyeee.CustomerCatalog.Services.CustomerWrite;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerPostNoteTests : BaseWebIntegrationTest
    {
        [Fact]
        public async Task should_add_note_to_customer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            Context.AddCustomer(new Customer
            {
                Id = customerId,
                Name = "test",
                Status = 1,
                CreationTime = DateTime.Now
            });
            var command = new AddCustomerNoteCommand
            {
                Text = "Some text",
                Id = Guid.NewGuid(),
                CustomerId = customerId
            };
            var expected = new List<Note>
            {
                new Note
                {
                    Id = command.Id,
                    Text = command.Text
                }
            };

            // Act
            var actual = await InvokePost($"api/customer/note", command);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.Created);
            var actualCustomer = Context.GetCustomer(customerId);
            actualCustomer.Notes.Should().BeEquivalentTo(expected);
        }
    }
}