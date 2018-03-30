using System;

namespace yyyeee.CustomerCatalog.Services.CustomerRead
{
    public class NoteDto
    {
        public NoteDto(Guid id, string text)
        {
            Id = id;
            Text = text;
        }

        public Guid Id { get; }
        public string Text { get; }

    }
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