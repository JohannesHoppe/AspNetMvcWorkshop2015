using System.Linq;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void DeleteCustomer(Customer customer);
        void CreateCustomer(Customer customer);
        bool UpdateCustomer(int id, Customer customer);
        bool CustomerExists(int id);
    }
}