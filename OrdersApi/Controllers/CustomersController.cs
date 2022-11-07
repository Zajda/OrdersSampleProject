using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    [NotNull] private readonly ICustomersService _customersService;

    public CustomersController([NotNull] ICustomersService customersService)
    {
        _customersService = customersService ?? throw new ArgumentNullException(nameof(customersService));
    }

    [HttpGet]
    public Task<IActionResult> GetAllCustomers()
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.GetAllAsync()));
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetCustomerById(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.GetCustomerByIdAsync(id)));
    }

    [HttpPut("create")]
    public Task<IActionResult> CreateCustomer(Customer customer)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.CreateAsync(customer)));
    }
    
    [HttpPut("update")]
    public Task<IActionResult> UpdateCustomer(Customer customer)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.UpdateAsync(customer)));
    }

    [HttpDelete("delete")]
    public Task<IActionResult> DeleteCustomer(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.DeleteAsync(id)));
    }
}