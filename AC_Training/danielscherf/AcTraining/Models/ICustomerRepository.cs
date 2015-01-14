using System.Collections.Generic;
using System.Linq;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        int Insert(Customer obj);
        int Update(Customer obj);
        Customer Delete(int id);
        bool CustomerExists(int id);
    }
}