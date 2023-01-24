using JHTest.DAL.Repositories;
using Microsoft.Extensions.Hosting;
using Tweetinvi;
using Tweetinvi.Models.V2;

namespace JHTest.BL.Services
{
    public class TwitterService : ITwitterService
    {

        private readonly ITwitterRepository _twtRepository;


        public TwitterService(ITwitterRepository twtRepository)
        {
            _twtRepository = twtRepository;
        }

        public async Task Add(TweetV2 tweet)
        {
            await Task.Run(() => _twtRepository.Add(tweet));
        }

        public async Task<int> Count()
        {
            return await Task.Run(() => _twtRepository.Count());
        }

        public async Task<string[]> GetTopHashtags(int count = 10)
        {
            return await Task.Run(() => _twtRepository.GetTopHashtags());
        }
    }
}