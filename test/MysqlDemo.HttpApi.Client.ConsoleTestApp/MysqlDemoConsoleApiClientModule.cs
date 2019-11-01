using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MysqlDemo.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MysqlDemoHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MysqlDemoConsoleApiClientModule : AbpModule
    {
        
    }
}
