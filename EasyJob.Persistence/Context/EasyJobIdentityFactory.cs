using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyJob.Persistence.Context
{
    public class EasyJobIdentityFactory : IDesignTimeDbContextFactory<EasyJobIdentityContext>
    {
        public EasyJobIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyJobIdentityContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=EasyJob;Trusted_Connection=True;");

            return new EasyJobIdentityContext(optionsBuilder.Options);
        }
    }
}