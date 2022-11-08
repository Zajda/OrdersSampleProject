using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleProject.Controllers;

/// <summary>
/// Controller handling the items data.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ItemsController : Controller
{
    [NotNull] private readonly IItemsService _itemsService;

    public ItemsController([NotNull] IItemsService itemsService)
    {
        _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
    }

    /// <summary>
    /// Returns all the items.
    /// </summary>
    /// <returns>A collection of all items.</returns>
    [HttpGet]
    public Task<IActionResult> GetAllItems()
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.GetAllAsync()));
    }

    /// <summary>
    /// Returns a single specific item.
    /// </summary>
    /// <param name="id">Identification of a specific item.</param>
    /// <returns>A single item data.</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetItemById(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.GetItemByIdAsync(id)));
    }
    
    /// <summary>
    /// Creates a new item entity.
    /// </summary>
    /// <param name="item">Newly created item object.</param>
    /// <returns>Returns newly created item obejct.</returns>
    [HttpPut("create")]
    public Task<IActionResult> CreateItem(Item item)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.CreateAsync(item)));
    }
    
    /// <summary>
    /// Updates a single item data.
    /// </summary>
    /// <param name="item">Updated item data.</param>
    /// <returns>Returns updated item object.</returns>
    [HttpPut("update")]
    public Task<IActionResult> UpdateItem(Item item)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.UpdateAsync(item)));
    }

    /// <summary>
    /// Deletes a specific item.
    /// </summary>
    /// <param name="id">Identification of a specific item.</param>
    /// <returns>Returns a confirmation of deletion.</returns>
    [HttpDelete("delete")]
    public Task<IActionResult> DeleteItem(int id)
    {
        return Task.FromResult<IActionResult>(Ok(_itemsService.DeleteAsync(id)));
    }
}