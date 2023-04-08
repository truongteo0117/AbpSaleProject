using Acme.SaleProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.SaleProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SaleProjectController : AbpControllerBase
{
    protected SaleProjectController()
    {
        LocalizationResource = typeof(SaleProjectResource);
    }
}
