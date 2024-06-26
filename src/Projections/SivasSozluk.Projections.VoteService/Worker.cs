using SivasSozluk.Common.Events.Entry;
using SivasSozluk.Common.Infrastructure;
using SivasSozluk.Common;

namespace SivasSozluk.Projections.VoteService
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

            var voteService = new Services.VoteService(connStr);

            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.CreateEntryVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<CreateEntryVoteEvent>(vote =>
                {
                    voteService.CreateEntryVote(vote).GetAwaiter().GetResult();
                    _logger.LogInformation("Create Entry Received EntryId: {0}, VoteType: {1}", vote.EntryId, vote.VoteType);
                })
                .StartConsuming(SozlukConstants.CreateEntryVoteQueueName);
        }
    }
}
