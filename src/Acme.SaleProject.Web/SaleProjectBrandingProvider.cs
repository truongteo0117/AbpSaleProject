using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.SaleProject.Web;

[Dependency(ReplaceServices = true)]
public class SaleProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SaleProject";
}
