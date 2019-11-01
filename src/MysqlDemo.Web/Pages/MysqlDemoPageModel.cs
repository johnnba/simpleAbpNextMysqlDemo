using MysqlDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MysqlDemo.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MysqlDemoPageModel : AbpPageModel
    {
        protected MysqlDemoPageModel()
        {
            LocalizationResourceType = typeof(MysqlDemoResource);
        }
    }
}