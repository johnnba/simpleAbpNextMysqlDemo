using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MysqlDemo.Users;
using Shouldly;
using Volo.Abp.Identity;
using Xunit;

namespace MysqlDemo.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IdentityUserManager here).
     * Only test your own domain services.
     */
    public class SampleDomainTests : MysqlDemoDomainTestBase
    {
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;
        private readonly DemoUserManager _demoUserManager;

        public SampleDomainTests()
        {
            _identityUserRepository = GetRequiredService<IIdentityUserRepository>();
            _identityUserManager = GetRequiredService<IdentityUserManager>();
            _demoUserManager = GetRequiredService<DemoUserManager>();
        }

        [Fact]
        public async Task Should_Set_Email_Of_A_User()
        {
            IdentityUser adminUser;

            /* Need to manually start Unit Of Work because
             * FirstOrDefaultAsync should be executed while db connection / context is available.
             */
            await WithUnitOfWorkAsync(async () =>
            {
                adminUser = await _identityUserRepository
                    .FindByNormalizedUserNameAsync("ADMIN");

                await _identityUserManager.SetEmailAsync(adminUser, "newemail@abp.io");
                await _identityUserRepository.UpdateAsync(adminUser);
            });

            adminUser = await _identityUserRepository.FindByNormalizedUserNameAsync("ADMIN");
            adminUser.Email.ShouldBe("newemail@abp.io");
        }

        [Fact]
        public async Task Should_Count_Greater_Than_0_User()
        {
            List<AppUser>  users=null;
            await WithUnitOfWorkAsync(async () =>
                {
                    var userRess = await _demoUserManager.ExcuteQueryAsync<AppUser>($"select * from abpusers");
                    users = userRess.ToList();
                });
            Assert.NotNull(users);
            users.ShouldContain(x=>x.Name== "ADMIN");
        }
    }
}
