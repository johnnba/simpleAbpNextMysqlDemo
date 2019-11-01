using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MysqlDemo.Data
{
    /* This is used if database provider does't define
     * IMysqlDemoDbSchemaMigrator implementation.
     */
    public class NullMysqlDemoDbSchemaMigrator : IMysqlDemoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}