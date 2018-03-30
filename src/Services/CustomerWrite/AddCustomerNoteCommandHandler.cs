using yyyeee.CustomerCatalog.Services.DataLayer;
using yyyeee.CustomerCatalog.Services.DataLayer.Models;

namespace yyyeee.CustomerCatalog.Services.CustomerWrite
{
    public class AddCustomerNoteCommandHandler : ICommandHandler<AddCustomerNoteCommand>
    {
        private readonly LiteDatabaseFactory _liteDatabaseFactory;

        public AddCustomerNoteCommandHandler(LiteDatabaseFactory liteDatabaseFactory)
        {
            _liteDatabaseFactory = liteDatabaseFactory;
        }

        public void Handle(AddCustomerNoteCommand command)
        {
            using (var database = _liteDatabaseFactory.Create())
            {
                var customers = database.GetCustomersCollection();

                var customer = customers.FindById(command.CustomerId);
                customer.Notes.Add(new Note{ Id = command.Id, Text = command.Text });

                customers.Update(customer);
            }
        }
    }
}