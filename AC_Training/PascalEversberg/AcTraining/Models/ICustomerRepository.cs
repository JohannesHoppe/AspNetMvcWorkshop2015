using System.Linq;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int index);
        int UpdateCustomer(int index, Customer cust);
        int CreateCustomer(Customer cust);
        Customer DeleteCustomer(int index);
        bool CustomerExists(int id);
    }
}