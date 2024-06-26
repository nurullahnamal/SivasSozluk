using SivasSozluk.Common.Events.Entry;
using SivasSozluk.Common.Infrastructure;
using SivasSozluk.Common;

namespace SivasSozluk.Projections.FavoriteService
{

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connStr = configuration.GetConnectionString("SqlServer");

            var favService = new Services.FavoriteService(connStr);

            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.FavExchangeName)
                .EnsureQueue(SozlukConstants.CreateEntryFavQueueName, SozlukConstants.FavExchangeName)
                .Receive<CreateEntryFavEvent>(fav =>
                {
                    favService.CreateEntryFav(fav).GetAwaiter().GetResult();
                    _logger.LogInformation($"Received EntryId {fav.EntryId}");
                })
                .StartConsuming(SozlukConstants.CreateEntryFavQueueName);
        }
    }
}