using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public MyContext context;
        private readonly IFoo _foo;
        private readonly IFoo2 _foo2;

        public ValuesController(MyContext context, IFoo foo, IFoo2 foo2)
        {
            this.context = context;
            _foo = foo;
            _foo2 = foo2;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var order = context.Orders.First(r => r.OrderID == 5);
            var task1 = Task.Run(() => _foo.Update(order));
            var task2 = Task.Run(() => _foo2.Update(order));
            Task.WaitAll(task1, task2);
            return new string[] {"value1", "value2"};
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
