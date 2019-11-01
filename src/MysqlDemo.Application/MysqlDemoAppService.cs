using System;
using System.Collections.Generic;
using System.Text;
using MysqlDemo.Localization;
using Volo.Abp.Application.Services;

namespace MysqlDemo
{
    /* Inherit your application services from this class.
     */
    public abstract class MysqlDemoAppService : ApplicationService
    {
        protected MysqlDemoAppService()
        {
            LocalizationResource = typeof(MysqlDemoResource);
        }
    }
}
