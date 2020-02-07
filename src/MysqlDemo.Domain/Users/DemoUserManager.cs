using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MysqlDemo.Users
{
    public class DemoUserManager : DomainService
    {
        private readonly IReadOnlyBasicRepository<AppUser, Guid> _users;

        public DemoUserManager(IReadOnlyBasicRepository<AppUser, Guid> users)
        {
            _users = users;
        }
        public async Task<IQueryable<TDto>> ExcuteQueryAsync<TDto>(FormattableString sql, params object[] parameters) where TDto : class
        {

            if (_users.GetDbContext() is { } dbcontext)
            {
                var res1 = await dbcontext.Database.ExecuteSqlInterpolatedAsync(sql);
                Logger.LogInformation($"query result lines is {res1}");
                var res2 = await dbcontext.Database.ExecuteSqlRawAsync(sql.ToString());
                Logger.LogInformation($"query result lines is {res2}");
                var viewRes = dbcontext.Set<TDto>().FromSqlInterpolated<TDto>(sql);
                Logger.LogInformation($"query result count is {viewRes}");
                return viewRes;
            }

            return null;

        }
    }
}
