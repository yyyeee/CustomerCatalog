using System;
using yyyeee.CustomerCatalog.Services.CustomerRead;

namespace yyyeee.CustomerCatalog.Services.CustomerWrite
{
    public class UpdateCustomerCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
    }
}