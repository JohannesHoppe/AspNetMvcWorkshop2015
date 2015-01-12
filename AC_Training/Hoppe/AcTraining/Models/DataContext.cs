using System.Data.Common;
using System.Data.Entity;

namespace AcTraining.Models
{
    public class DataContext: DbContext 
    {
        public DataContext(DbConnection connection) : base(connection, true)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

    }
}