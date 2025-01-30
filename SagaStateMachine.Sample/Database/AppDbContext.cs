using Microsoft.EntityFrameworkCore;

namespace SagaStateMachine.Sample.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
