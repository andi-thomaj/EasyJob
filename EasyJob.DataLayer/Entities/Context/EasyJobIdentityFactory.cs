using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyJob.DataLayer.Entities.Context
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