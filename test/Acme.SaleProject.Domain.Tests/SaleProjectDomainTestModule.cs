using Acme.SaleProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.SaleProject;

[DependsOn(
    typeof(SaleProjectEntityFrameworkCoreTestModule)
    )]
public class SaleProjectDomainTestModule : AbpModule
{

}
