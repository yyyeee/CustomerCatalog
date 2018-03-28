using System;

namespace yyyeee.CustomerCatalog.Services.CustomerRead
{
    public class CustomerDto
    {
        public CustomerDto(Guid id, string name, CustomerStatus status, DateTimeOffset creationTime)
        {
            Id = id;
            Name = name;
            Status = status;
            CreationTime = creationTime;
        }

        public Guid Id { get; }
        public string Name { get; }
        public CustomerStatus Status { get; }
        public DateTimeOffset CreationTime { get; }
    }
}