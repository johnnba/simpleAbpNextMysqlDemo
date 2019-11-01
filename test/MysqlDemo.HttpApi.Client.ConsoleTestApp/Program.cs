﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Threading;

namespace MysqlDemo.HttpApi.Client.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<MysqlDemoConsoleApiClientModule>())
            {
                application.Initialize();

                var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();
                AsyncHelper.RunSync(() => demo.RunAsync());

                Console.WriteLine("Press ENTER to stop application...");
                Console.ReadLine();
            }
        }
    }
}
