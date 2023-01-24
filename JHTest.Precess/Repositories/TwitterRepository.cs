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
        private Dictionary<string, TweetV2> _tweets { get; set; } = new();
        private readonly Dictionary<string, int> _hashtagCounts = new();

        public int Count()
        {
            return _tweets.Count;
        }

        public string[] GetTopHashtags(int count = 10)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));

            return _hashtagCounts
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .Take(count)
                .ToArray();
        }

        public void Add(TweetV2 tweet)
        {
            if (_tweets.ContainsKey(tweet.Id)) return;

            _tweets.Add(tweet.Id, tweet);

            if (tweet.Entities?.Hashtags == null || tweet.Entities.Hashtags.Length == 0) return;

            foreach (var hashtag in tweet.Entities.Hashtags)
            {
                var tag = hashtag.Tag;
                if (_hashtagCounts.ContainsKey(tag))
                    _hashtagCounts[tag] = _hashtagCounts[tag] + 1;
                else
                    _hashtagCounts.Add(tag, 1);
            }
        }

    }
}
