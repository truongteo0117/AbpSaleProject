using Volo.Abp.Modularity;

namespace Acme.SaleProject;

[DependsOn(
    typeof(SaleProjectApplicationModule),
    typeof(SaleProjectDomainTestModule)
    )]
public class SaleProjectApplicationTestModule : AbpModule
{

}
