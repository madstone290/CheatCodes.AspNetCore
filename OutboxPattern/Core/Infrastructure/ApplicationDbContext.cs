using Microsoft.EntityFrameworkCore;
using OutboxPattern.Core.Domain;

namespace OutboxPattern.Core.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }
    }
}
