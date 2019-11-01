using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MysqlDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(MysqlDemoEntityFrameworkCoreModule)
        )]
    public class MysqlDemoEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MysqlDemoMigrationsDbContext>();
        }
    }
}
