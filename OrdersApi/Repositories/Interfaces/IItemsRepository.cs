using ApiSampleProject.Models;

namespace ApiSampleProject.Repositories.Interfaces;

public interface IItemsRepository : IRepositoryBase<Item>
{
    ValueTask<Item?> GetItemByIdAsync(int id);
}