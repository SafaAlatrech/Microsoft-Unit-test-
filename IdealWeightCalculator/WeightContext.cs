using Microsoft.EntityFrameworkCore;

namespace IdealWeightCalculator
{
    public class WeightContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=Weights_Database; Integrated security=true");
        }

    }
}
