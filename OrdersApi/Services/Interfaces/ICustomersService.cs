using ApiSampleProject.Models;

namespace ApiSampleProject.Services.Interfaces;

public interface ICustomersService : IServiceBase<Customer>
{
    ValueTask<Customer?> GetCustomerByIdAsync(int id);
}