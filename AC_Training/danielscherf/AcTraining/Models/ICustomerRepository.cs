using System.Collections.Generic;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        int Insert(Customer obj);
        int Update(Customer obj);
        Customer Delete(int id);
        bool CustomerExists(int id);
    }
}