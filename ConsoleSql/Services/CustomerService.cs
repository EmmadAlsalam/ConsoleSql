using ConsoleSql.Entities;
using ConsoleSql.Models;
using ConsoleSql.Repositories;

namespace ConsoleSql.Services;

internal class CustomerService(AddressRepository addressRepository, CustomerRepository customerRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;




    public bool CreateCustomer(CustomersRegistrationForm form)
    {
        var customerEntity = new CustomersEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            AddressId = _addressRepository.Create(new AdressEntity
            {
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City = form.City,
            })
        };

        int result = _customerRepository.Create(customerEntity);
        return result > 0; 
    }
}
