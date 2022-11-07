using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.DbContexts;
using ApiSampleProject.Models;
using ApiSampleProject.Repositories.Interfaces;

namespace ApiSampleProject.Repositories;

public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
{
    [NotNull] private readonly OrdersSampleDbContext _dbContext;

    public CustomersRepository(OrdersSampleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public ValueTask<Customer?> GetCustomerByIdAsync(int id)
    {
        return _dbContext.FindAsync<Customer>(id);
    }
}