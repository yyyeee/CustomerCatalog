using System;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.DataLayer;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.Services.CustomerWrite
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly LiteDatabaseFactory _liteDatabaseFactory;

        public UpdateCustomerCommandHandler(LiteDatabaseFactory liteDatabaseFactory)
        {
            _liteDatabaseFactory = liteDatabaseFactory;
        }

        public void Handle(UpdateCustomerCommand command)
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                var customers = database.GetCustomersCollection();

                var customer = customers.FindById(command.Id);
                customer.Status = (int) command.Status;
                customer.Name = command.Name;
                
                customers.Update(customer);
            }
        }
    }
}