using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Models.DTOs;
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
    public async Task<IActionResult>  GetAllOrders()
    {
        var data = await _ordersService.GetAllAsync();
        
        var mapped = _mapper.Map<List<OrderDto>>(data);

        return Ok(mapped);
    }

    /// <summary>
    /// Get a single specific order.
    /// </summary>
    /// <param name="id">Identification of the specific order.</param>
    /// <returns>Returns data about a specific order.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var data = await _ordersService.GetOrderByIdAsync(id);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }
    
    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">Newly created order entity.</param>
    /// <returns>Returns the newly created entity.</returns>
    [HttpPut("create")]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        var data = await _ordersService.CreateAsync(order);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }
    
    /// <summary>
    /// Updates an existing order entity.
    /// </summary>
    /// <param name="order">Updated order entity.</param>
    /// <returns>Returns the updated entity.</returns>
    [HttpPut("update")]
    public async Task<IActionResult> UpdateOrder(Order order)
    {
        var data = await _ordersService.UpdateAsync(order);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }

    /// <summary>
    /// Deletes an order.
    /// </summary>
    /// <param name="id">Identification of a specific order.</param>
    /// <returns>Returns a confirmation of a deletion.</returns>
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var data = await _ordersService.DeleteAsync(id);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }
}