using System.Data.Entity;

namespace AcTraining.Models
{
    public class DataContext: DbContext 
    {
        public DbSet<Customer> Customers { get; set; }
    }
}