using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MysqlDemo.Users;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Users;

namespace MysqlDemo.EntityFrameworkCore
{
    public static class MysqlDemoDbContextModelCreatingExtensions
    {
        public static void ConfigureMysqlDemo(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<AppGuild>(b =>
            {
                b.ToTable("AppGuilds");
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Id).ValueGeneratedNever();
            });
            builder.ConfigureIdentityServer(options =>
            {
                options.DatabaseProvider = EfCoreDatabaseProvider.MySql;
            });
            //            builder.ConfigureIdentityServerForMySQL();
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}