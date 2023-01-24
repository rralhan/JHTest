using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;

namespace JHTest.DAL.Repositories
{
    public interface ITwitterRepository
    {
        void Add(TweetV2 tweet);
        int Count();
        string[] GetTopHashtags(int count = 10);
    }
}
