using MysqlDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MysqlDemo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MysqlDemoController : AbpController
    {
        protected MysqlDemoController()
        {
            LocalizationResource = typeof(MysqlDemoResource);
        }
    }
}