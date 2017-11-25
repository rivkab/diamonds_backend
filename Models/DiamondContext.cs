using Microsoft.EntityFrameworkCore;

namespace DiamondsApi.Models
{
    public class DiamondContext : DbContext
    {
        public DiamondContext(DbContextOptions<DiamondContext> options)
            : base(options)
        {
        }

        public DbSet<Diamond> Diamonds { get; set; }

    }
}