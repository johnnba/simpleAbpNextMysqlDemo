using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MysqlDemo.Data;
using Volo.Abp.DependencyInjection;

namespace MysqlDemo.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreMysqlDemoDbSchemaMigrator 
        : IMysqlDemoDbSchemaMigrator, ITransientDependency
    {
        private readonly MysqlDemoMigrationsDbContext _dbContext;

        public EntityFrameworkCoreMysqlDemoDbSchemaMigrator(MysqlDemoMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}