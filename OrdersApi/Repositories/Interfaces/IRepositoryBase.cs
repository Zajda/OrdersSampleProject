using ApiSampleProject.Models.Interfaces;

namespace ApiSampleProject.Repositories.Interfaces;

public interface IRepositoryBase<T>
    where T : class, IBaseModel
{
    IQueryable<T> GetAllAsync();

    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}