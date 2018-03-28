using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web
{
    public class BaseWebIntegrationTest : IDisposable
    {
        protected readonly HttpClient Client;
        protected readonly CustomerContext Context;
        private readonly TestServer _server;

        protected BaseWebIntegrationTest()
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
            Context = new CustomerContext(config);
        }
        
        public void Dispose()
        {
            Context.Cleanup();
            Client.Dispose();
            _server.Dispose();
        }
    }
}