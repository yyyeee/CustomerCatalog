﻿using System;
using System.Collections.Generic;

namespace yyyeee.CustomerCatalog.Services.CustomerRead
{
    public interface ICustomerProvider
    {
        ICollection<CustomerDto> GetAll();
        ICollection<NoteDto> GetNotesForCustomer(Guid id);
    }
}