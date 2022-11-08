using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Models.DTOs;
using ApiSampleProject.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleProject.Controllers;

/// <summary>
/// Controller handling the customer data
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    [NotNull] private readonly ICustomersService _customersService;
    [NotNull] private readonly IMapper _mapper;

    public CustomersController([NotNull] ICustomersService customersService, [NotNull] IMapper mapper)
    {
        _customersService = customersService ?? throw new ArgumentNullException(nameof(customersService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Returns a all the customers.
    /// </summary>
    /// <returns>Customer data</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var data = await _customersService.GetAllAsync();
        
        //var mapped = _mapper.Map<CustomerDto>(data);

        //return Ok(mapped);

        return Ok(data);
    }

    /// <summary>
    /// Returns a single customer.
    /// </summary>
    /// <param name="id">Identification of the customer.</param>
    /// <returns>Data about a single customer.</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetCustomerById(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.GetCustomerByIdAsync(id)));
    }

    /// <summary>
    /// Create a new customer entity.
    /// </summary>
    /// <param name="customer">Customer object to be created.</param>
    /// <returns>Newly created customer data.</returns>
    [HttpPut("create")]
    public Task<IActionResult> CreateCustomer(Customer customer)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.CreateAsync(customer)));
    }
    
    /// <summary>
    /// Updates data about a customer.
    /// </summary>
    /// <param name="customer">Updated customer entity.</param>
    /// <returns>Updated customer data.</returns>
    [HttpPut("update")]
    public Task<IActionResult> UpdateCustomer(Customer customer)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.UpdateAsync(customer)));
    }

    /// <summary>
    /// Deletes a customer entity.
    /// </summary>
    /// <param name="id">Identification of a customer.</param>
    /// <returns>Returns confirmation of deleting.</returns>
    [HttpDelete("delete")]
    public Task<IActionResult> DeleteCustomer(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_customersService.DeleteAsync(id)));
    }
}