using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Acme.SaleProject;

public class SaleProjectWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<SaleProjectWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
