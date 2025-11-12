using CarService2.DL.Interfaces;
using CarService2.Models.Entities;

namespace CarService2.DL.Repositories
{
    internal class CustomerStaticRepository : ICustomerStaticRepository
    {
        public List<Customer> GetAllCustomers()
        {
            return MyStaticDb.StaticDb.Customers;
        }

        public Customer? GetCustomerById(int id)
        {
            return MyStaticDb.StaticDb.Customers
                .FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            MyStaticDb.StaticDb.Customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);

            if (customer != null)
            {
                MyStaticDb.StaticDb.Customers.Remove(customer);
            }
        }
    }
}
