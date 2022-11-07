using ApiSampleProject.Models;

namespace ApiSampleProject.Repositories.Interfaces;

public interface ICustomersRepository : IRepositoryBase<Customer>
{
    ValueTask<Customer?> GetCustomerByIdAsync(int id);
}