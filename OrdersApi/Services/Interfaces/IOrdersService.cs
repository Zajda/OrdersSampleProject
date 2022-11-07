using ApiSampleProject.Models;

namespace ApiSampleProject.Services.Interfaces;

public interface IOrdersService : IServiceBase<Order>
{
    ValueTask<Order?> GetOrderByIdAsync(int id);
}