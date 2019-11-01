using Volo.Abp.Settings;

namespace MysqlDemo.Settings
{
    public class MysqlDemoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MysqlDemoSettings.MySetting1));
        }
    }
}
