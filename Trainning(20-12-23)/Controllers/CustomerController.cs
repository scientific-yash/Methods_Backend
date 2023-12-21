using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trainning_20_12_23_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static readonly List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1,FirstName = "Yash", LastName = "Goel", Address = "Sangam Vihar", PhoneNumber = "123456789"},
            new Customer { Id = 2,FirstName = "Ravi", LastName = "Singh", Address = "Rithala", PhoneNumber = "123456789"},
            new Customer { Id = 3,FirstName = "Karan", LastName = "Singh", Address = "Hauz Khas", PhoneNumber = "123456789"},
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var a = customers.Find(a => a.Id == id);
            if(a == null)
            {
                return NotFound();
            }

            return a;
        }

        [HttpPost]
        public ActionResult<Customer> Post(Customer c) {
            customers.Add(c);
            return NoContent();
        }

        [HttpPut]
        public ActionResult<Customer> Put(int id, Customer cust)
        {
            var a = customers.Find(a => a.Id == id);
            if (a == null)
            {
                return NotFound();
            }
            a.FirstName = cust.FirstName;
            a.LastName = cust.LastName;
            a.Address = cust.Address;
            a.PhoneNumber = cust.PhoneNumber;
            
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Customer> Delete(int id)
        {
            var c = customers.Find(c => c.Id == id);
            if (c == null)
                return NotFound();
            customers.Remove(c);

            return NoContent() ;
        }
    }
}
