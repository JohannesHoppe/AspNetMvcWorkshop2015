using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AcTraining.Models
{
    public class DataContext : DbContext 
    {
        public DataContext(DbConnection connection) : base(connection, true)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<StringLengthAttributeConvention>();
        }

    }
}