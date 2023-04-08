using Acme.SaleProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.SaleProject.Permissions;

public class SaleProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SaleProjectPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SaleProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SaleProjectResource>(name);
    }
}
