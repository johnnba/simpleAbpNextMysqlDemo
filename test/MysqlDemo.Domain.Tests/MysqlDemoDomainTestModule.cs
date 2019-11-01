using MysqlDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MysqlDemo
{
    [DependsOn(
        typeof(MysqlDemoEntityFrameworkCoreTestModule)
        )]
    public class MysqlDemoDomainTestModule : AbpModule
    {

    }
}