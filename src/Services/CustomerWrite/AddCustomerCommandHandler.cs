using System;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.DataLayer;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.Services.CustomerWrite
{
    public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
    {
        private readonly LiteDatabaseFactory _liteDatabaseFactory;

        public AddCustomerCommandHandler(LiteDatabaseFactory liteDatabaseFactory)
        {
            _liteDatabaseFactory = liteDatabaseFactory;
        }

        public void Handle(AddCustomerCommand command)
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                var customers = database.GetCustomersCollection();
                var isAlreadyCreated = customers.Exists(c => c.Id == command.Id);
                if (isAlreadyCreated)
                {
                    throw new CustomerAlreadyCreatedException();
                }

                customers.Insert(new Customer
                {
                    Id = command.Id,
                    Name = command.Name,
                    Status = (int) CustomerStatus.Prospective,
                    CreationTime = DateTimeOffset.Now.UtcDateTime
                });
            }
        }
    }
}