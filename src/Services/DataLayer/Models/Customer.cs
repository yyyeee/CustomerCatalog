using System;
using System.Collections.Generic;

namespace yyyeee.CustomerCatalog.Services.DataLayer.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}