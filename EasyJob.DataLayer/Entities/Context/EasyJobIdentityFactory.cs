using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyJob.DataLayer.Entities.Context
{
    public class EasyJobIdentityFactory : IDesignTimeDbContextFactory<EasyJobIdentityContext>
    {
        public EasyJobIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyJobIdentityContext>();
            optionsBuilder.UseSqlServer("");

            return new EasyJobIdentityContext(optionsBuilder.Options);
        }
    }
}