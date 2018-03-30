using System;
using System.Collections.Generic;
using System.Linq;
using yyyeee.CustomerCatalog.Services.DataLayer;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.Services.CustomerRead
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly LiteDatabaseFactory _liteDatabaseFactory;

        public CustomerProvider(LiteDatabaseFactory liteDatabaseFactory)
        {
            _liteDatabaseFactory = liteDatabaseFactory;
        }

        public ICollection<CustomerDto> GetAll()
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                var customers = database.GetCollection<Customer>(LiteDatabaseCollectionNames.Customers);
                CustomerDto CreateCustomerDto(Customer c) 
                    => new CustomerDto(c.Id, c.Name, (CustomerStatus) c.Status, c.CreationTime);
                var customerDtos = customers.FindAll().Select(CreateCustomerDto).ToList();
                return customerDtos;
            }
        }

        public ICollection<NoteDto> GetNotesForCustomer(Guid id)
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                var customers = database.GetCollection<Customer>(LiteDatabaseCollectionNames.Customers);
                
                var customer = customers.FindById(id);
                return customer.Notes.Select(n => new NoteDto(n.Id, n.Text)).ToList();
            }
        }
    }
}