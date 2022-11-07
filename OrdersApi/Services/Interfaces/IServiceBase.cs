namespace ApiSampleProject.Services.Interfaces;

public interface IServiceBase<T>
{
    Task<IQueryable<T>> GetAllAsync();

    Task<T> CreateAsync(T entity);

    Task<T> DeleteAsync(int id);

    Task<T> UpdateAsync(T entity);
}