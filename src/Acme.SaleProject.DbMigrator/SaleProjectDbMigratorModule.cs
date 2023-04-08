using Acme.SaleProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.SaleProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SaleProjectEntityFrameworkCoreModule),
    typeof(SaleProjectApplicationContractsModule)
    )]
public class SaleProjectDbMigratorModule : AbpModule
{

}
