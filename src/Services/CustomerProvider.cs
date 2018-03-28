using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Microsoft.Extensions.Configuration;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.Services
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly IConfiguration _configuration;

        public CustomerProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<CustomerDto> GetAll()
        {
            using (var database = new LiteDatabase(_configuration.GetConnectionString("CustomerDatabase")))
            {
                var customers = database.GetCollection<Customer>("Customers");
                return customers.FindAll().Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = (CustomerStatus) c.Status
                }).ToList();
            }
        }
    }

    public interface ICustomerProvider
    {
        ICollection<CustomerDto> GetAll();
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
    }

    public enum CustomerStatus
    {
    }
}