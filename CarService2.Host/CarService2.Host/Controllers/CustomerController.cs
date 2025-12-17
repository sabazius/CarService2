using CarService2.BL.Interfaces;
using CarService2.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarService2.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(nameof(GetAllCustomers))]
        public IActionResult GetAllCustomers()
        {
            var customers =
                _customerService.GetAllCustomers();

            if (customers.Count == 0)
            {
                return NoContent();
            }

            return Ok(customers);
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost(nameof(AddCustomer))]
        public IActionResult AddCustomer([FromBody] AddCustomerRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) ||
                string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("Name and Email are required.");
            }
            _customerService.AddCustomer(request);
            return Ok();
        }

        [HttpDelete(nameof(DeleteCustomer))]
        public IActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }
            _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
