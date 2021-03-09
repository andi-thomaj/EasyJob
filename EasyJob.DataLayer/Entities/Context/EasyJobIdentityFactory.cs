using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyJob.DataLayer.Entities.Context
{
    public class EasyJobIdentityFactory : IDesignTimeDbContextFactory<EasyJobIdentityContext>
    {
        private readonly IConfiguration _configuration;

        public EasyJobIdentityFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public EasyJobIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyJobIdentityContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            return new EasyJobIdentityContext(optionsBuilder.Options);
        }
    }
}