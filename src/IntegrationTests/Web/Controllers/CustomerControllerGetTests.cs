using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class CustomerControllerGetTests : IDisposable
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public CustomerControllerGetTests()
        {
            _server = new TestServer(
                 new WebHostBuilder()
                    .UseEnvironment("Testing")
                    .UseStartup<Startup>());
            _client = _server.CreateClient();

//            _context = server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        }
        
        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public async Task should_return_all_customers()
        {
            // Arrange
            // TODO
            var expected = new List<string>
            {
                "Test customer"
            };

            // Act
            var actual = await _client.GetStringAsync("/api/customer");

            // Assert
             var actualResult = JsonConvert.DeserializeObject<ICollection<string>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task should_return_empty_collection_when_no_customers()
        {
            // Arrange
            var expected = new List<string>();

            // Act
            var actual = await _client.GetStringAsync("/api/customer");

            // Assert
            AssertCollectionOfCustomers(actual, expected);
        }

        private static void AssertCollectionOfCustomers(string actual, ICollection<string> expected)
        {
            var actualResult = JsonConvert.DeserializeObject<ICollection<string>>(actual);
            actualResult.Should().BeEquivalentTo(expected);
        }
    }
}