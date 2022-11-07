using ApiSampleProject.Models;
using ApiSampleProject.Repositories.Interfaces;
using ApiSampleProject.Services.Interfaces;

namespace ApiSampleProject.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepo;

    public OrdersService(IOrdersRepository ordersRepo)
    {
        _ordersRepo = ordersRepo;
    }

    public Task<IQueryable<Order>> GetAllAsync()
    {
        return Task.FromResult(_ordersRepo.GetAllAsync());
    }

    public ValueTask<Order?> GetOrderByIdAsync(int id)
    {
        if (id == null) throw new NullReferenceException(nameof(id));

        return _ordersRepo.GetOrderByIdAsync(id);
    }

    public Task<Order> CreateAsync(Order entity)
    {
        return (Task<Order>) _ordersRepo.CreateAsync(entity);
    }

    public Task<Order> DeleteAsync(int id)
    {
        var order = _ordersRepo.GetOrderByIdAsync(id).Result;

        if (order == null) throw new ArgumentNullException($"Order with {id} does not exist!");

        return (Task<Order>) _ordersRepo.DeleteAsync(order);
    }

    public Task<Order> UpdateAsync(Order entity)
    {
        return (Task<Order>) _ordersRepo.UpdateAsync(entity);
    }
}