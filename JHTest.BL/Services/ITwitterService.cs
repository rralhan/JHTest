using Tweetinvi.Models.V2;

namespace JHTest.BL.Services
{
    public interface ITwitterService
    {
        Task<int> Count();
        Task<string[]> GetTopHashtags(int count = 10);
        Task Add(TweetV2 tweet);
    }
}
