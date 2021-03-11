using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.DataLayer.Entities.Context
{
    public class EasyJobIdentityContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public EasyJobIdentityContext(DbContextOptions<EasyJobIdentityContext> options)
            :base(options)
        {
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<ApprovalStatuses> ApprovalStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>(u =>
            {
                u.ToTable("Users");
            });

            builder.Entity<Posts>()
                .Property(p => p.ApprovalStatusesId)
                .HasColumnName("StatusId");
            
            builder.Entity<Posts>()
                .Property(p => p.JobText)
                .HasColumnType("text");
        }
    }
}