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
        // Command bus to add
        private readonly ICommandHandler<AddCustomerCommand> _addCustomerCommandHandler;
        private readonly ICommandHandler<UpdateCustomerCommand> _updateCustomerCommandHandler;

        public CustomerController(
            ICustomerProvider customerProvider,
            ICommandHandler<AddCustomerCommand> addCustomerCommandHandler, 
            ICommandHandler<UpdateCustomerCommand> updateCustomerCommandHandler)
        {
            _customerProvider = customerProvider;
            _addCustomerCommandHandler = addCustomerCommandHandler;
            _updateCustomerCommandHandler = updateCustomerCommandHandler;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> GetAll()
        {
            return _customerProvider.GetAll();
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateCustomerCommand command)
        {
            _updateCustomerCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] AddCustomerCommand command)
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
