using System;
using System.Collections.Generic;
using LiteDB;

namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    public class CustomerContext
    {
        public void AddCustomers(IEnumerable<Customer> customers)
        {
            using (var database = new LiteDatabase(ConfigurationProvider.DatabaseAddress))
            {
                var collection = database.GetCollection<Customer>("Customers");
                collection.Insert(customers);
            }
        }

        public void Cleanup()
        {
            using (var database = new LiteDatabase(ConfigurationProvider.DatabaseAddress))
            {
                database.DropCollection("Customers");
            }
        }
    }

    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreationTime { get; set; }
    }
}