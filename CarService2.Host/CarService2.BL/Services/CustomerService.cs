using CarService2.BL.Interfaces;
using CarService2.DL.Interfaces;
using CarService2.Models.Entities;
using CarService2.Models.Requests;
using CarService2.Models.Responses;

namespace CarService2.BL.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerStaticRepository _customerRepository;

        public CustomerService(ICustomerStaticRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<GetCustomerByIdResponse> GetAllCustomers()
        {
            var customers= 
                _customerRepository.GetAllCustomers();

            var result = customers
                .Select(c => new GetCustomerByIdResponse()
                {
                  Email = c.Email,
                  Id = c.Id,
                  Name = c.Name
              });

            return result.ToList();
        }

        public GetCustomerByIdResponse? GetCustomerById(int id)
        {
            var customer =_customerRepository.GetCustomerById(id);

            if (customer == null) return null;

            return new GetCustomerByIdResponse()
            {
                Email = customer.Email,
                Id = customer.Id,
                Name = customer.Name
            }
        }

        public void AddCustomer(AddCustomerRequest request)
        {
           _customerRepository.AddCustomer(new Customer()
           {
               Email = request.Email,
               Name = request.Name
           });
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }
    }
}
