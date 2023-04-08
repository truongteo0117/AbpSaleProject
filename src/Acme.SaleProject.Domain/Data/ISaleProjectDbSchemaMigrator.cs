using System.Threading.Tasks;

namespace Acme.SaleProject.Data;

public interface ISaleProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
