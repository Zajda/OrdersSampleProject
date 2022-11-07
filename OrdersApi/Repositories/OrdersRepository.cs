using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.DbContexts;
using ApiSampleProject.Models;
using ApiSampleProject.Repositories.Interfaces;

namespace ApiSampleProject.Repositories;

public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
{
    [NotNull] private readonly OrdersSampleDbContext _dbContext;

    public OrdersRepository(OrdersSampleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public ValueTask<Order?> GetOrderByIdAsync(int id)
    {
        return _dbContext.FindAsync<Order>(id);
    }
}