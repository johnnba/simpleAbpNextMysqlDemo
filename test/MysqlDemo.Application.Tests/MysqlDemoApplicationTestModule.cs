using Volo.Abp.Modularity;

namespace MysqlDemo
{
    [DependsOn(
        typeof(MysqlDemoApplicationModule),
        typeof(MysqlDemoDomainTestModule)
        )]
    public class MysqlDemoApplicationTestModule : AbpModule
    {

    }
}