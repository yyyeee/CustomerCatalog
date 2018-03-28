using Microsoft.Extensions.Configuration;
using yyyeee.CustomerCatalog.Services.DataLayer;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.IntegrationTests.Web
{
    public class CustomerContext
    {
        private readonly LiteDatabaseFactory _liteDatabaseFactory;

        public CustomerContext(IConfiguration configuration)
        {
            _liteDatabaseFactory = new LiteDatabaseFactory(configuration);
        }

        public void AddCustomer(Customer customer)
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                var customers = database.GetCollection<Customer>("Customers");
                customers.Insert(customer);
            }
        }

        public void Cleanup()
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                database.DropCollection(LiteDatabaseCollectionNames.Customers);
            }
        }
    }
}