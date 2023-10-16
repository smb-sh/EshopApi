using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var result = new ObjectResult(_customerRepository.GetAll())
            {
                // set status code
                StatusCode = (int)HttpStatusCode.OK
            };
            // adding header
            Request.HttpContext.Response.Headers.Add("X-Count", _customerRepository.CountCustomer().ToString());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {   
            // check user exist or not
            if (await CustomerExists(id))
            {
                var customer = await _customerRepository.Find(id); 
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }
        
        private async Task<bool> CustomerExists(int id)
        {
            return await _customerRepository.IsExists(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            // check validation of model 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _customerRepository.Add(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            await _customerRepository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerRepository.Remove(id);
            return Ok();
        }
    }
}
