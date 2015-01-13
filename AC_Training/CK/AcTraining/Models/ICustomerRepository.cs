using System.Linq;
using System.Web.Http.Description;

namespace AcTraining.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        int UpdateCustomer(int id, Customer customer);

        [ResponseType(typeof(Customer))]
        int CreateCustomer(Customer customer);

        [ResponseType(typeof(Customer))]
        Customer DeleteCustomer(int id);

        bool CustomerExists(int id);
    }
}