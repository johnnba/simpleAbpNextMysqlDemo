using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace MysqlDemo.Data
{
    public class MysqlDemoDbMigrationService : ITransientDependency
    {
        public ILogger<MysqlDemoDbMigrationService> Logger { get; set; }

        private readonly IDataSeeder _dataSeeder;
        private readonly IMysqlDemoDbSchemaMigrator _dbSchemaMigrator;

        public MysqlDemoDbMigrationService(
            IDataSeeder dataSeeder,
            IMysqlDemoDbSchemaMigrator dbSchemaMigrator)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrator = dbSchemaMigrator;

            Logger = NullLogger<MysqlDemoDbMigrationService>.Instance;
        }

        public async Task MigrateAsync()
        {
            Logger.LogInformation("Started database migrations...");

            Logger.LogInformation("Migrating database schema...");
            await _dbSchemaMigrator.MigrateAsync();

            Logger.LogInformation("Executing database seed...");
            await _dataSeeder.SeedAsync();

            Logger.LogInformation("Successfully completed database migrations.");
        }
    }
}