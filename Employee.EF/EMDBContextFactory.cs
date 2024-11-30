using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EM.EF
{
    public class EMDBContextFactory
    {
        private readonly IConfiguration _configuration;

        public EMDBContextFactory(IConfiguration configuration) => _configuration = configuration;

        public EMDBContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<EMDBContext>();

            optionsBuilder.UseSqlServer(connectionString, sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(3);
                sqlServerAction.CommandTimeout(30);
            });

            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.EnableSensitiveDataLogging(true);

            return new EMDBContext(optionsBuilder.Options);
        }
    }
}
