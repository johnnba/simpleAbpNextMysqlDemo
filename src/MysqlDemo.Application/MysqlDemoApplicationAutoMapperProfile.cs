﻿using AutoMapper;
using MysqlDemo.Users;
using Volo.Abp.Identity;

namespace MysqlDemo
{
    public class MysqlDemoApplicationAutoMapperProfile : Profile
    {
        public MysqlDemoApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<AppUser, IdentityUserDto>();
        }
    }
}
