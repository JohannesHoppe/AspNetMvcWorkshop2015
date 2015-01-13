using System.Linq;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        bool UpdateCustomer(int id, Customer customer);
        bool InsertCustomer(Customer customer);
        bool DeleteCustomer(int id, out Customer deletedCustomer);
        bool CustomerExists(int id);
    }
}