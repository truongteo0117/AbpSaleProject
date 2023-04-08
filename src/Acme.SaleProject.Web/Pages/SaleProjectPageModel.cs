using Acme.SaleProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.SaleProject.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SaleProjectPageModel : AbpPageModel
{
    protected SaleProjectPageModel()
    {
        LocalizationResourceType = typeof(SaleProjectResource);
    }
}
