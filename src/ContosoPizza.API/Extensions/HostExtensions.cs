using System;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using ContosoPizza.API.Data;

namespace ContosoPizza.API.Extensions;

public static class HostExtensions
{
    public static void CreateDummyDatabase(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        IServiceProvider services = scope.ServiceProvider;
        DatabaseContext context = services.GetRequiredService<DatabaseContext>();
        DbInitializer.Initialize(context);
    }
}
