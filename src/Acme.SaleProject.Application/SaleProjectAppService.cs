using System;
using System.Collections.Generic;
using System.Text;
using Acme.SaleProject.Localization;
using Volo.Abp.Application.Services;

namespace Acme.SaleProject;

/* Inherit your application services from this class.
 */
public abstract class SaleProjectAppService : ApplicationService
{
    protected SaleProjectAppService()
    {
        LocalizationResource = typeof(SaleProjectResource);
    }
}
