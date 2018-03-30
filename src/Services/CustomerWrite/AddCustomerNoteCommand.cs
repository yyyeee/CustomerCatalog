using System;

namespace yyyeee.CustomerCatalog.Services.CustomerWrite
{
    public class AddCustomerNoteCommand
    {
        public Guid CustomerId { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}