using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : Controller
{
    [NotNull] private readonly IItemsService _itemsService;

    public ItemsController([NotNull] IItemsService itemsService)
    {
        _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
    }

    [HttpGet]
    public Task<IActionResult> GetAllItems()
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.GetAllAsync()));
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetItemById(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.GetItemByIdAsync(id)));
    }
    
    [HttpPut("create")]
    public Task<IActionResult> CreateItem(Item item)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.CreateAsync(item)));
    }
    
    [HttpPut("update")]
    public Task<IActionResult> UpdateItem(Item item)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.UpdateAsync(item)));
    }

    [HttpDelete("delete")]
    public Task<IActionResult> DeleteItem(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.DeleteAsync(id)));
    }
}