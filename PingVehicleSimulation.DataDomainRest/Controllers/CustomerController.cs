using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;

namespace PingVehicleSimulation.DataDomainRest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
        private readonly IUnitOfWork<Customer> _customerUnitOfWork;

        public CustomerController(IUnitOfWork<Customer> customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerUnitOfWork.RepositoryObject.ListAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {

            var customer = await _customerUnitOfWork.RepositoryObject.FindByIdAsync(id);

            return Ok(customer);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            var newCustomer = await _customerUnitOfWork.RepositoryObject.AddAsync(customer);
            await _customerUnitOfWork.SaveChangesToDbAsync();

            return Ok(newCustomer);
        }

        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customerUnitOfWork.RepositoryObject.UpdateAsync(customer);
            await _customerUnitOfWork.SaveChangesToDbAsync();

            return Ok(customer);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCustomer(Customer customer)
        {
            await _customerUnitOfWork.RepositoryObject.DeleteAsync(customer);
            await _customerUnitOfWork.SaveChangesToDbAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            var customer = await _customerUnitOfWork.RepositoryObject.FindByIdAsync(id);

            if (customer == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            await _customerUnitOfWork.RepositoryObject.DeleteAsync(customer);
            await _customerUnitOfWork.SaveChangesToDbAsync();

            return Ok();

        }
    }
}
