

using CarService2.Models.Entities;

namespace CarService2.DL.Interfaces
{
    public interface ICustomerStaticRepository
    {
        List<Customer> GetAllCustomers();

        Customer? GetCustomerById(int id);

        void AddCustomer(Customer customer);

        void DeleteCustomer(int id);
    }
}
