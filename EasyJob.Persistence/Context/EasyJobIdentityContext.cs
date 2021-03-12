using EasyJob.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.Persistence.Context
{
    public class EasyJobIdentityContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public EasyJobIdentityContext(DbContextOptions<EasyJobIdentityContext> options)
            :base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(u =>
            {
                u.ToTable("Users");
            });

            builder.Entity<Post>()
                .Property(p => p.ApprovalStatusId)
                .HasColumnName("StatusId");
            
            builder.Entity<Post>()
                .Property(p => p.JobText)
                .HasColumnType("text");
        }
    }
}