using System.Data.Entity;

namespace ExportPlatform.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}
