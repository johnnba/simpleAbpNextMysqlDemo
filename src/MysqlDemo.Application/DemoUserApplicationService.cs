using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MysqlDemo.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace MysqlDemo
{
   public class DemoUserApplicationService:ApplicationService, IDemoUserApplicationService
    {
        private readonly DemoUserManager _manager;

        public DemoUserApplicationService(DemoUserManager manager)
        {
            _manager = manager;
        }
        public async Task<List<IdentityUserDto>> GetAppUserTest()
        {
            var users = await _manager.ExcuteQueryAsync<AppUser>($"select * from abpusers");
            
            return users.ToList().Select(x => ObjectMapper.Map<AppUser, IdentityUserDto>(x)).ToList();

        }
    }
}
