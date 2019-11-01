using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace MysqlDemo.Web
{
    [Dependency(ReplaceServices = true)]
    public class MysqlDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MysqlDemo";
    }
}
