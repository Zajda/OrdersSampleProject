using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleProject.Controllers;

/// <summary>
/// Controller handling data about orders.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [NotNull] private readonly IOrdersService _ordersService;
    [NotNull] private readonly IMapper _mapper;

    public OrdersController([NotNull] IOrdersService ordersService, [NotNull] IMapper mapper)
    {
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Returns all the orders.
    /// </summary>
    /// <returns>Returns a collection of all orders.</returns>
    [HttpGet]
    public async Task<IQueryable<Order>> GetAllOrders()
    {
        return await _ordersService.GetAllAsync();
    }

    /// <summary>
    /// Get a single specific order.
    /// </summary>
    /// <param name="id">Identification of the specific order.</param>
    /// <returns>Returns data about a specific order.</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetOrderById(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.GetOrderByIdAsync(id)));
    }
    
    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">Newly created order entity.</param>
    /// <returns>Returns the newly created entity.</returns>
    [HttpPut("create")]
    public Task<IActionResult> CreateOrder(Order order)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.CreateAsync(order)));
    }
    
    /// <summary>
    /// Updates an existing order entity.
    /// </summary>
    /// <param name="order">Updated order entity.</param>
    /// <returns>Returns the updated entity.</returns>
    [HttpPut("update")]
    public Task<IActionResult> UpdateOrder(Order order)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.UpdateAsync(order)));
    }

    /// <summary>
    /// Deletes an order.
    /// </summary>
    /// <param name="id">Identification of a specific order.</param>
    /// <returns>Returns a confirmation of a deletion.</returns>
    [HttpDelete("delete")]
    public Task<IActionResult> DeleteOrder(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.DeleteAsync(id)));
    }
}