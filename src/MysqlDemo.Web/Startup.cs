using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MysqlDemo.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<MysqlDemoWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
