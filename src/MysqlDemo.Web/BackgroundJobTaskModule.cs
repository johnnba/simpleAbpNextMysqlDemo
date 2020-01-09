using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.MailKit;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace MysqlDemo.Web
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpMailKitModule),
        typeof(AbpBackgroundJobsModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule)
    )]
    public class BackgroundJobTaskModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobWorkerOptions>(options =>
            {
                options.DefaultTimeout = 86400; //1 days (as seconds)
                //Configure for fast running
                options.JobPollPeriod = 1000;
                options.DefaultFirstWaitDuration = 1;
                options.DefaultWaitFactor = 1;
            });
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = true; //set to false can Disable job execution
                //                options.AddJob<EmailSendingJob>();
                //                options.AddJob<BackgroundEmailSendingJob>();
            });


        }

        public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {
            var email = context.ServiceProvider
                .GetRequiredService<IEmailSender>();
        }
    }
}
