using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.SaleProject.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.SaleProject.EntityFrameworkCore;

public class EntityFrameworkCoreSaleProjectDbSchemaMigrator
    : ISaleProjectDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSaleProjectDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SaleProjectDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SaleProjectDbContext>()
            .Database
            .MigrateAsync();
    }
}
