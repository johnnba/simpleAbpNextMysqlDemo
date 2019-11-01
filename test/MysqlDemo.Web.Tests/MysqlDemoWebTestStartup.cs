using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MysqlDemo
{
    public class MysqlDemoWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<MysqlDemoWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}