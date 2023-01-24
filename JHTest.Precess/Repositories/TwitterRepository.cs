using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;

namespace JHTest.DAL.Repositories
{
    public class TwitterRepository : ITwitterRepository
    {
        public Dictionary<string, TweetV2> Tweets { get; set; } = new();
        private readonly Dictionary<string, int> HashtagCounts = new();

        public int Count()
        {
            return Tweets.Count;
        }

        public string[] GetTopHashtags(int count = 10)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));

            return HashtagCounts
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .Take(count)
                .ToArray();
        }

        public void Add(TweetV2 tweet)
        {
            if (Tweets.ContainsKey(tweet.Id)) return;

            Tweets.Add(tweet.Id, tweet);

            if (tweet.Entities?.Hashtags == null || tweet.Entities.Hashtags.Length == 0) return;

            foreach (var hashtag in tweet.Entities.Hashtags)
            {
                var tag = hashtag.Tag;
                if (HashtagCounts.ContainsKey(tag))
                    HashtagCounts[tag] = HashtagCounts[tag] + 1;
                else
                    HashtagCounts.Add(tag, 1);
            }
        }

    }
}
