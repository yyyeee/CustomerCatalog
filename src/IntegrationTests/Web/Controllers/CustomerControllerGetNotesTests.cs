using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerGetNotesTests : BaseWebIntegrationTest
    {
        [Fact]
        public async Task should_return_all_for_customer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var notes = new List<Note>
            {
                new Note{ Id = Guid.NewGuid(), Text = "text1"},
                new Note{ Id = Guid.NewGuid(), Text = "text2"},
                new Note{ Id = Guid.NewGuid(), Text = "text3"},
            };
            var expected = notes.Select(n => new NoteDto(n.Id, n.Text));
            AddCustomerToContext(customerId, notes);

            // Act
            var actual = await CallGetNotes(customerId);

            // Assert
             var actualResult = JsonConvert.DeserializeObject<ICollection<NoteDto>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }

        private void AddCustomerToContext(Guid id, ICollection<Note> notes)
        {
            Context.AddCustomer(new Customer
            {
                Id = id,
                Name = "test",
                Status = 1,
                CreationTime = DateTime.Now,
                Notes = notes
            });
        }

        [Fact]
        public async Task should_return_empty_collection_when_no_notes()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            AddCustomerToContext(customerId, new List<Note>());
            var expected = new List<NoteDto>();

            // Act
            var actual = await CallGetNotes(customerId);

            // Assert
            AssertCollectionOfNotes(actual, expected);
        }

        private static void AssertCollectionOfNotes(string actual, ICollection<NoteDto> expected)
        {
            var actualResult = JsonConvert.DeserializeObject<ICollection<NoteDto>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }

        private Task<string> CallGetNotes(Guid customerId)
        {
            return Client.GetStringAsync($"/api/customer/note/{customerId}");
        }
    }
}