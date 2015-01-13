using System.Linq;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        IQueryable<Customer> GetCustomers();
        void UpdateCustomer(Customer pCustomer);
        Customer DeleteCustomer(int id);
        CustomerState.State CreateCustomer(Customer customer);
        bool CustomerExists(int id);
    }
}