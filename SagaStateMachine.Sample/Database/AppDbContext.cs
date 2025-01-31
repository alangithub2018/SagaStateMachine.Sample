using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Sample.Sagas;

namespace SagaStateMachine.Sample.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify the correlation id as the key
            modelBuilder.Entity<NewsletterOnboardingSagaData>(entity =>
            {
                // as a suggestion, it is recommended to index the correlation id for performance reasons
                entity.HasKey(e => e.CorrelationId);
            });
        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<NewsletterOnboardingSagaData> SagaData { get; set; }
    }
}
