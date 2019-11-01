using MysqlDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MysqlDemo.Permissions
{
    public class MysqlDemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MysqlDemoPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MysqlDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MysqlDemoResource>(name);
        }
    }
}
