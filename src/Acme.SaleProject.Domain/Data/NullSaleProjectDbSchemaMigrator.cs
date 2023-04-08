using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.SaleProject.Data;

/* This is used if database provider does't define
 * ISaleProjectDbSchemaMigrator implementation.
 */
public class NullSaleProjectDbSchemaMigrator : ISaleProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
