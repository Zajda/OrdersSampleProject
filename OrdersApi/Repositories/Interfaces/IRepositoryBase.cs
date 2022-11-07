namespace ApiSampleProject.Repositories.Interfaces;

public interface IRepositoryBase<T>
    where T : class
{
    IQueryable<T> GetAllAsync();

    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}