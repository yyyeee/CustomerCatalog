using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
                .Build();
            var uniqueConnectionString = $"{config.GetConnectionString("CustomerDatabase")}.{Guid.NewGuid()}";
            var uniqueConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddInMemoryCollection(new[]
                    {new KeyValuePair<string, string>("ConnectionStrings:CustomerDatabase", uniqueConnectionString)})
                .Build();

            _server = new TestServer(
                new WebHostBuilder()
                    .UseConfiguration(uniqueConfig)
                    .UseStartup<Startup>());
            Client = _server.CreateClient();
            Context = new CustomerContext(uniqueConfig);
        }
        
        public void Dispose()
        {
            Context.Cleanup();
            Client.Dispose();
            _server.Dispose();
        }


        protected async Task<HttpResponseMessage> InvokePost(string address, object payload)
        {
            var result =
                await Client.PostAsync(address,
                    new StringContent(
                        JsonConvert.SerializeObject(payload),
                        Encoding.UTF8,
                        "application/json"));
            return result;
        }
    }
}