using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
