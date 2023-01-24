using JHTest.DAL.Repositories;
using Microsoft.Extensions.Hosting;
using Tweetinvi;



namespace JHTest.BL.Services
{
    public class TweetStreamService : BackgroundService
    {
        private readonly ITwitterClient _twitterClient;
        private readonly ITwitterService _twtService;
        public TweetStreamService(ITwitterService twtService,
            ITwitterClient twitterClient)
        {
            _twtService = twtService;
            _twitterClient = twitterClient;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var stream = _twitterClient.StreamsV2.CreateSampleStream();
            stream.TweetReceived += (_, eventArgs) =>
            {
                _twtService.Add(eventArgs.Tweet);
            };
            await stream.StartAsync();
        }
    }
}
