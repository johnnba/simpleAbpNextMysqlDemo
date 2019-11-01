using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using MysqlDemo.Data;
using Serilog;
using Serilog.Events;
using Volo.Abp;
using Volo.Abp.Threading;

namespace MysqlDemo.DbMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogging();

            using (var application = AbpApplicationFactory.Create<MysqlDemoDbMigratorModule>(options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            }))
            {
                application.Initialize();
                string start=string.Empty  ;
                Console.WriteLine("Input start to start migration database");
                while  (true)
                {
                    if(start=="start")
                    {
                        try
                        {
                            AsyncHelper.RunSync(
                                () => application
                                    .ServiceProvider
                                    .GetRequiredService<MysqlDemoDbMigrationService>()
                                    .MigrateAsync()
                            );
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            
                        }
                        Console.WriteLine("End the migration");
                        Console.WriteLine("Input start to start migration database");
                    }

                    start = Console.ReadLine();
                    if (start=="exit")
                    {
                        break;
                    }
                }
                

                application.Shutdown();
            }
        }

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
#if DEBUG
                .MinimumLevel.Override("MysqlDemo", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("MysqlDemo", LogEventLevel.Information)
#endif
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/logs.txt"))
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
