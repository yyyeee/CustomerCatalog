using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using yyyeee.CustomerCatalog.Services;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.CustomerWrite;

namespace yyyeee.CustomerCatalog.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerProvider _customerProvider;
        private readonly ICommandHandler<AddCustomerCommand> _addCustomerCommandHandler;

        public CustomerController(
            ICustomerProvider customerProvider,
            ICommandHandler<AddCustomerCommand> addCustomerCommandHandler)
        {
            _customerProvider = customerProvider;
            _addCustomerCommandHandler = addCustomerCommandHandler;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> GetAll()
        {
            return _customerProvider.GetAll();
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post(AddCustomerCommand command)
        {
            try
            {
                _addCustomerCommandHandler.Handle(command);
                return Created("api/customer", new {command.Id});
            }
            catch (CustomerAlreadyCreatedException)
            {
                return new StatusCodeResult((int)HttpStatusCode.Conflict);  
            }
        }
    }
}
