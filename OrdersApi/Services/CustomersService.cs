using System.Net;
using ApiSampleProject.Models;
using ApiSampleProject.Repositories.Interfaces;
using ApiSampleProject.Services.Interfaces;

namespace ApiSampleProject.Services;

public class CustomersService : ICustomersService
{
    private readonly ICustomersRepository _customersRepo;

    public CustomersService(ICustomersRepository customersRepo)
    {
        _customersRepo = customersRepo;
    }

    public Task<IQueryable<Customer>> GetAllAsync()
    {
        return Task.FromResult(_customersRepo.GetAllAsync());
    }

    public Task<Customer> CreateAsync(Customer entity)
    {
        return (Task<Customer>) _customersRepo.CreateAsync(entity);
    }

    public Task<Customer> DeleteAsync(int id)
    {
        var customer = _customersRepo.GetCustomerByIdAsync(id).Result;
        if (customer == null)
        {
            throw new ArgumentNullException($"Customer with {id} does not exist!");
        }

        // Soft delete
        customer.IsDeleted = true;
        return UpdateAsync(customer);
    }

    public Task<Customer> UpdateAsync(Customer entity)
    {
        return (Task<Customer>) _customersRepo.UpdateAsync(entity);
    }

    public ValueTask<Customer?> GetCustomerByIdAsync(int id)
    {
        return _customersRepo.GetCustomerByIdAsync(id);
    }
}