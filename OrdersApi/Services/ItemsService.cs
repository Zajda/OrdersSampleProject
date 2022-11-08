using ApiSampleProject.Models;
using ApiSampleProject.Repositories.Interfaces;
using ApiSampleProject.Services.Interfaces;

namespace ApiSampleProject.Services;

public class ItemsService : IItemsService
{
    private readonly IItemsRepository _itemsRepo;

    public ItemsService(IItemsRepository itemsRepo)
    {
        _itemsRepo = itemsRepo;
    }

    public Task<IQueryable<Item>> GetAllAsync()
    {
        return Task.FromResult(_itemsRepo.GetAllAsync());
    }

    public Task<Item> CreateAsync(Item entity)
    {
        return (Task<Item>) _itemsRepo.CreateAsync(entity);
    }

    public Task<Item> DeleteAsync(int id)
    {
        var item = _itemsRepo.GetItemByIdAsync(id).Result;

        if (item == null) throw new ArgumentNullException($"Item with {id} does not exist!");

        item.IsDeleted = true;
        return UpdateAsync(item);
    }

    public Task<Item> UpdateAsync(Item entity)
    {
        return (Task<Item>) _itemsRepo.UpdateAsync(entity);
    }

    public ValueTask<Item?> GetItemByIdAsync(int id)
    {
        return _itemsRepo.GetItemByIdAsync(id);
    }
}