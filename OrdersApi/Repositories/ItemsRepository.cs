using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.DbContexts;
using ApiSampleProject.Models;
using ApiSampleProject.Repositories.Interfaces;

namespace ApiSampleProject.Repositories;

public class ItemsRepository : RepositoryBase<Item>, IItemsRepository
{
    [NotNull] private readonly OrdersSampleDbContext _dbContext;

    public ItemsRepository(OrdersSampleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public ValueTask<Item> GetItemByIdAsync(int id)
    {
        return _dbContext.FindAsync<Item>(id);
    }
}