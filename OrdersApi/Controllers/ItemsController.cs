using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models;
using ApiSampleProject.Models.DTOs;
using ApiSampleProject.Services.Interfaces;
using AutoMapper;
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
    [NotNull] private readonly IMapper _mapper;

    public ItemsController([NotNull] IItemsService itemsService, [NotNull] IMapper mapper)
    {
        _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Returns all the items.
    /// </summary>
    /// <returns>A collection of all items.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var data = await _itemsService.GetAllAsync();
        
        var mapped = _mapper.Map<List<ItemDto>>(data);

        return Ok(mapped);
    }

    /// <summary>
    /// Returns a single specific item.
    /// </summary>
    /// <param name="id">Identification of a specific item.</param>
    /// <returns>A single item data.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var data = await _itemsService.GetItemByIdAsync(id);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }
    
    /// <summary>
    /// Creates a new item entity.
    /// </summary>
    /// <param name="item">Newly created item object.</param>
    /// <returns>Returns newly created item obejct.</returns>
    [HttpPut("create")]
    public async Task<IActionResult> CreateItem(Item item)
    {
        var data = await _itemsService.CreateAsync(item);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }
    
    /// <summary>
    /// Updates a single item data.
    /// </summary>
    /// <param name="item">Updated item data.</param>
    /// <returns>Returns updated item object.</returns>
    [HttpPut("update")]
    public async Task<IActionResult> UpdateItem(Item item)
    {
        var data = await _itemsService.UpdateAsync(item);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }

    /// <summary>
    /// Deletes a specific item.
    /// </summary>
    /// <param name="id">Identification of a specific item.</param>
    /// <returns>Returns a confirmation of deletion.</returns>
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var data = await _itemsService.DeleteAsync(id);
        
        var mapped = _mapper.Map<ItemDto>(data);

        return Ok(mapped);
    }
}