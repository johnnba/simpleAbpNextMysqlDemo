using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace MysqlDemo
{
    public class MysqlDemoTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        public Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */

            return Task.CompletedTask;
        }
    }
}