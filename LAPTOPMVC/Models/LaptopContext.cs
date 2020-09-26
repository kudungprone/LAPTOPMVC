using System.Data.Entity;

namespace LAPTOPMVC.Models
{
    public class LaptopContext : DbContext
    {
        public LaptopContext() : base("Laptopconnect")
        {
        }

        public DbSet<Laptop> laptop { get; set; }
    }
}