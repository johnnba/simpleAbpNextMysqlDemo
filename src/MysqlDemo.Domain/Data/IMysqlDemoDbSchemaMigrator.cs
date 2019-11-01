using System.Threading.Tasks;

namespace MysqlDemo.Data
{
    public interface IMysqlDemoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
