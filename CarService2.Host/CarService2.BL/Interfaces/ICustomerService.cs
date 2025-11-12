using CarService2.Models.Requests;
using CarService2.Models.Responses;

namespace CarService2.BL.Interfaces
{
    public interface ICustomerService
    {
        List<GetCustomerByIdResponse> GetAllCustomers();

        GetCustomerByIdResponse? GetCustomerById(int id);

        void AddCustomer(AddCustomerRequest request);

        void DeleteCustomer(int id);
    }
}
