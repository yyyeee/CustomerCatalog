using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace yyyeee.CustomerCatalog.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
