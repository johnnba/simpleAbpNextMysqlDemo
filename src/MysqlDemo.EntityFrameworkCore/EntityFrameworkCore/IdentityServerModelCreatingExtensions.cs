using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.Clients;

namespace MysqlDemo.EntityFrameworkCore
{
    public static class IdentityServerModelCreatingExtensions
    {
        public static void ConfigureIdentityServerForMySQL(this ModelBuilder builder)
        {
            // Solve the problem of MySQL migration
            // https://github.com/abpframework/abp/issues/1920

            builder.Entity<ApiSecret>(b =>
            {
                // After trying, you can also set it to 400
                b.Property(x => x.Value).HasMaxLength(300);
            });

            builder.Entity<ClientPostLogoutRedirectUri>(b =>
            {
                b.Property(x => x.PostLogoutRedirectUri).HasMaxLength(300); // or 400 ？
            });

            builder.Entity<ClientRedirectUri>(b =>
            {
                b.Property(x => x.RedirectUri).HasMaxLength(300); // or 400 ？
            });

            builder.Entity<ClientSecret>(b =>
            {
                b.Property(x => x.Value).HasMaxLength(300); // or 400 ？
            });

        }
    }
}
