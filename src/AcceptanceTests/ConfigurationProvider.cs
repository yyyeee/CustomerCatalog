using System.IO;
using Microsoft.Extensions.Configuration;

namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    public static class ConfigurationProvider
    {
        public static string DatabaseAddress => GetConfiguration().GetSection("DatabaseAddress").Value;
        public static string ApplicationAddress => GetConfiguration().GetSection("ApplicationAddress").Value;

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json");
            var configuration = builder.Build();
            return configuration;
        }
    }
}