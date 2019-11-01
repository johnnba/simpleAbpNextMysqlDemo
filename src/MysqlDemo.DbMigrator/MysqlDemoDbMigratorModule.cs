using MysqlDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MysqlDemo.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MysqlDemoEntityFrameworkCoreDbMigrationsModule),
        typeof(MysqlDemoApplicationContractsModule)
        )]
    public class MysqlDemoDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
