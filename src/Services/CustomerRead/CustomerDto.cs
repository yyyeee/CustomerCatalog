using System;

namespace yyyeee.CustomerCatalog.Services.CustomerRead
{
    public class CustomerDto
    {
        public CustomerDto(int id, string name, CustomerStatus status, DateTimeOffset creationTime)
        {
            Id = id;
            Name = name;
            Status = status;
            CreationTime = creationTime;
        }

        public int Id { get; }
        public string Name { get; }
        public CustomerStatus Status { get; }
        public DateTimeOffset CreationTime { get; }
    }
}