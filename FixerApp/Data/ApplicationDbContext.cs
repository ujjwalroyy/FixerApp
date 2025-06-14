
using FixerApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixrApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobRequest> JobRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
        public DbSet<SupportTicket> SupportTicket { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Review> Transactions { get; set; }
        public DbSet<Dispute> Dispute { get; set; }
        public DbSet<JobTimeline> JobTimeline { get; set; }

        public DbSet<WorkerAvailability> WorkerAvailability { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
