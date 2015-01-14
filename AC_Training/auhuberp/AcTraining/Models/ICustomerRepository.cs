using System.Data.Entity;
using System.Linq;

namespace AcTraining.Models
{
	public interface ICustomerRepository
	{
		IQueryable<Customer> GetCustomers();
		Customer GetCustomer(int id);
		CustomerRepository.UpdateRetVals UpdateCustomer(int id, Customer customer);
		void CreateCustomer(Customer customer);
		bool DeleteCustomer(int id, out Customer customer);
	}
}