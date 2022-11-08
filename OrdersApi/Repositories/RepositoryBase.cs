using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.DbContexts;
using ApiSampleProject.Models.Interfaces;
using ApiSampleProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiSampleProject.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, IBaseModel
{
    [NotNull] private readonly OrdersSampleDbContext _dbContext;

    protected RepositoryBase([NotNull] OrdersSampleDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IQueryable<T> GetAllAsync()
    {
        return _dbContext.Set<T>()
            .AsNoTracking()
            .Where(x => x.IsDeleted == false);
    }

    public Task CreateAsync(T entity)
    {
        _dbContext.AddAsync(entity);
        _dbContext.SaveChangesAsync();

        return Task.FromResult(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChangesAsync();

        return Task.FromResult(entity);
    }

    public Task DeleteAsync(T entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChangesAsync();

        return Task.FromResult(entity);
    }
}