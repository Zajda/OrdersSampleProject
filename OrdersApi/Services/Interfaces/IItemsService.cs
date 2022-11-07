using ApiSampleProject.Models;

namespace ApiSampleProject.Services.Interfaces;

public interface IItemsService : IServiceBase<Item>
{
    ValueTask<Item?> GetItemByIdAsync(int id);
}