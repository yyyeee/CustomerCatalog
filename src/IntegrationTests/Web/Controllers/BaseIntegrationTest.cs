using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web.Controllers
{
    public class BaseIntegrationTest : IDisposable
    {
        protected readonly HttpClient Client;
        private readonly TestServer _server;

        protected BaseIntegrationTest()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true)
                .Build();
            _server = new TestServer(
                new WebHostBuilder()
                    .UseConfiguration(config)
                    .UseStartup<Startup>());
            Client = _server.CreateClient();

            //            _context = server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        }
        
        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}