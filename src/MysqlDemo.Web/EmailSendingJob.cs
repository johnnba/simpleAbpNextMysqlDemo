using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MysqlDemo.Settings;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

namespace MysqlDemo.Web
{
    public class EmailSendingJob : BackgroundJob<EmailSendingArgs>, ITransientDependency
    {
        private readonly IEmailSender _emailSender;

        public EmailSendingJob(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        //  work well with the background job without IEmailSender injection
        //        public EmailSendingJob()
        //        {
        //            
        //        }
        public override void Execute(EmailSendingArgs args)
        {
            //            Logger.Log<EmailSendingArgs>(LogLevel.Information,new EventId(1001)
            //            ,args,null,null);
            //            _emailSender.SendAsync(
            //                args.EmailAddress,
            //                args.Subject,
            //                args.Body
            //            ).Wait();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("I'm  triggered without IEmailSender");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
