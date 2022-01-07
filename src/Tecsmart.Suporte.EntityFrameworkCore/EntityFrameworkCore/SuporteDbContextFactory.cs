using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Tecsmart.Suporte.Configuration;
using Tecsmart.Suporte.Web;

namespace Tecsmart.Suporte.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SuporteDbContextFactory : IDesignTimeDbContextFactory<SuporteDbContext>
    {
        public SuporteDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SuporteDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SuporteDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SuporteConsts.ConnectionStringName));

            return new SuporteDbContext(builder.Options);
        }
    }
}
