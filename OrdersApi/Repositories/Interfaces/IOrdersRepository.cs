using ApiSampleProject.Models;

namespace ApiSampleProject.Repositories.Interfaces;

public interface IOrdersRepository : IRepositoryBase<Order>
{
    ValueTask<Order?> GetOrderByIdAsync(int id);
}