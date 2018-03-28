using LiteDB;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.Services.DataLayer
{
    public static class LiteDatabaseExtensions
    {
        public static LiteCollection<Customer> GetCustomersCollection(this LiteDatabase database)
        {
            return database.GetCollection<Customer>(LiteDatabaseCollectionNames.Customers);
        }
    }
}