using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace MysqlDemo
{
    public interface IDemoUserApplicationService:IDomainService
    {
        Task<List<IdentityUserDto>> GetAppUserTest();
    }
}
