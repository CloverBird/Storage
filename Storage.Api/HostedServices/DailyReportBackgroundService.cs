using Storage.Core.Models;
using Storage.Core.Services;

namespace Storage.Api.HostedServices;

public class DailyReportBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public DailyReportBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();

            var reportsService = scope.ServiceProvider.GetRequiredService<IReportsService>();
            var productsService = scope.ServiceProvider.GetRequiredService<IProductsBatchesService>();

            var batches = productsService.GetProductsBatches()
                .Where(p => p.State == State.SoonSpoiled || p.State == State.Spoiled); // дневной отчет делаем только для тех товаров, что скоро испортятся

            if (batches.Any())
                reportsService.CreateReport(batches);

            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            //await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // для теста
        }
    }
}
