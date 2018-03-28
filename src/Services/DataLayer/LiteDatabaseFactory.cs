using LiteDB;
using Microsoft.Extensions.Configuration;

namespace yyyeee.CustomerCatalog.Services.DataLayer
{
    public class LiteDatabaseFactory
    {
        private readonly IConfiguration _configuration;

        public LiteDatabaseFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LiteDatabase Create()
        {
            return new LiteDatabase(_configuration.GetConnectionString("CustomerDatabase"));
        }
    }
}