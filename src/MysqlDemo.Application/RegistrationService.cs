using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MysqlDemo.Settings;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.SettingManagement;
using Volo.Abp.Users;

namespace MysqlDemo
{
    public class RegistrationService : ApplicationService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly ISettingManager _settingManager;
        private readonly ICurrentUser _user;
        private readonly IConfiguration _configuration;

        public RegistrationService(IBackgroundJobManager backgroundJobManager, ISettingManager settingManager, ICurrentUser user, IConfiguration configuration)
        {
            _backgroundJobManager = backgroundJobManager;
            _settingManager = settingManager;
            _user = user;
            _configuration = configuration;
        }

        public async Task ConfirmAsync()
        {
            //TODO: Create new user in the database...
            //            ServiceProvider.GetRequiredService<>()
            var host = _configuration["App:SelfUrl"];
            await _backgroundJobManager.EnqueueAsync(
                new EmailSendingArgs
                {
                    EmailAddress = _user.Email,
                    Subject = $"{_user.UserName},欢迎您使用海盗天眼辅助!",
                    Body = $"{host}/accounts/confirm/"
                }
            );
            //            await _backgroundJobManager.EnqueueAsync(new BackgroundEmailSendingJobArgs
            //            {
            //                To = _user.Email,
            //                Subject = $"{_user.UserName},欢迎您使用海盗天眼辅助!",
            //                Body = $"{host}/accounts/confirm/"
            //            });
        }
    }

}
