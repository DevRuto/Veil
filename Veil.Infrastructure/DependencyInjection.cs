using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Veil.Application.Interfaces;

namespace Veil.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<VeilContext>(dbContext =>
        {
            dbContext.UseInMemoryDatabase("Veil");
        });

        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<VeilContext>());
    }
}
