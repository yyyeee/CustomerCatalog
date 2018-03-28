using System;

namespace yyyeee.CustomerCatalog.Services.DataLayer.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreationTime { get; set; }
    }
}