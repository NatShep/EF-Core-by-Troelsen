using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace AutoLotDal_Core.EF
{
    public class AutoLotContextFactory: IDesignTimeDbContextFactory<AutoLotContext>
    {
        public AutoLotContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutoLotContext>();
            var connectionString =
                "Server=desktop-l8k07nf\\sqlexpress;Initial Catalog=AutoLotCore;User Id=sa;Password=123;" +
                "MultipleActiveResultSets=True;App=EntityFramework";
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            return new AutoLotContext();
        }
    }
}