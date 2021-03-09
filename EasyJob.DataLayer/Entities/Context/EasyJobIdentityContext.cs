using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.DataLayer.Entities.Context
{
    public class EasyJobIdentityContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public EasyJobIdentityContext(DbContextOptions<EasyJobIdentityContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>(u =>
            {
                u.ToTable("Users");
            });
        }
    }
}