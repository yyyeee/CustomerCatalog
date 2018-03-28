using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using yyyeee.CustomerCatalog.Services;
using yyyeee.CustomerCatalog.Services.CustomerRead;

namespace yyyeee.CustomerCatalog.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerProvider _customerProvider;

        public CustomerController(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerProvider.GetAll();
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
