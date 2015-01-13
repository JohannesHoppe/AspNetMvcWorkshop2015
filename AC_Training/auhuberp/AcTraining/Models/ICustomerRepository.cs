using System.Data.Entity;

namespace AcTraining.Models
{
	public interface ICustomerRepository
	{
		DbSet<Customer> GetCustomers();
		Customer GetCustomer(int id);
		CustomerRepository.UpdateRetVals UpdateCustomer(int id, Customer customer);
		void CreateCustomer(Customer customer);
		bool DeleteCustomer(int id, out Customer customer);
	}
}