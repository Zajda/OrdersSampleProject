using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [NotNull] private readonly IOrdersService _ordersService;

    public OrdersController([NotNull] IOrdersService ordersService)
    {
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
    }

    [HttpGet]
    public async Task<IQueryable<Order>> GetAllOrders()
    {
        return await _ordersService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetOrderById(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.GetOrderByIdAsync(id)));
    }
    
    [HttpPut("create")]
    public Task<IActionResult> CreateOrder(Order order)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.CreateAsync(order)));
    }
    
    [HttpPut("update")]
    public Task<IActionResult> UpdateOrder(Order order)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.UpdateAsync(order)));
    }

    [HttpDelete("delete")]
    public Task<IActionResult> DeleteOrder(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_ordersService.DeleteAsync(id)));
    }
}