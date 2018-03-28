using System;

namespace yyyeee.CustomerCatalog.Services.CustomerWrite
{
    public class AddCustomerCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}