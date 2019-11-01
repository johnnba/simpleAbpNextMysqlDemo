using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace MysqlDemo.Users
{
    public class AppGuild:FullAuditedAggregateRoot<Guid>
    {
        public AppGuild(Guid id,string name)
        {
            Id = id;
            Name = name;
        }

        public  string Name { get; set; }
        public  string Desc { get; set; }
        public  int Compacity { get; set; }
    }
}
