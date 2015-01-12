using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcTraining.Models
{
	public class DataContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
	}
}