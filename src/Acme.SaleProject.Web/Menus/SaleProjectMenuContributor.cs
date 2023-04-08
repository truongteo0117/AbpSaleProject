using System.Threading.Tasks;
using Acme.SaleProject.Localization;
using Acme.SaleProject.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.SaleProject.Web.Menus;

public class SaleProjectMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<SaleProjectResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                SaleProjectMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "SaleProject",
                l["Menu:SaleProject"],
                icon: "fa fa-book"
            ).AddItem(
                new ApplicationMenuItem(
                    "SaleProject.Customers",
                    l["Menu:Customers"],
                    url: "/Customers"
                )
            ).AddItem(
                new ApplicationMenuItem(
                    "SaleProject.Customers.History",
                    l["Menu:History"],
                    url: "/Customers/History"
                )
            )
        );
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
