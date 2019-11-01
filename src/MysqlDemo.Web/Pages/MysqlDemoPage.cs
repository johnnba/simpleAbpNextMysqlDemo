using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using MysqlDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MysqlDemo.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits MysqlDemo.Web.Pages.MysqlDemoPage
     */
    public abstract class MysqlDemoPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<MysqlDemoResource> L { get; set; }
    }
}
