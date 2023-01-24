using FluentAssertions;
using JHTest.DAL.Repositories;
using Tweetinvi.Models.V2;

namespace TestProject
{
    public class TwitterRepositoryTest
    {
        private readonly ITwitterRepository _twtRepo;
        public TwitterRepositoryTest()
        {
            _twtRepo = new TwitterRepository();
            AddTestTweets();
        }

        private void AddTestTweets()
        {

            var t1 = new TweetV2
            {
                Entities = new TweetEntitiesV2 { Hashtags = new[] { new HashtagV2 { Tag = "try1" } } },
                Id = "try1"
            };
            _twtRepo.Add(t1);

            var t2 = new TweetV2
            {
                Entities = new TweetEntitiesV2 { Hashtags = new[] { new HashtagV2 { Tag = "try2" } } },
                Id = "try2"
            };
            _twtRepo.Add(t2);
        }




        [Fact]
        public void Count_Returns_Int()
        {
            _twtRepo.Count().Should().Be(2);
        }

        [Theory]
        [InlineData(5)]
        public void Returns_Requested_Number(int count)
        {
            _twtRepo.GetTopHashtags().Length.Should().BeLessThanOrEqualTo(count);
        }
    }
}