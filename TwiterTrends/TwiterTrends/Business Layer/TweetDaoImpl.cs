using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;
using TwiterTrends.Utility;

namespace TwiterTrends.Business_Layer
{
    class TweetDaoImpl : ITweetDao
    {
        public List<Tweet> GetTweets()
        {
            return TweetParser.ParseTweets("C:\\Ksenia\\tweets.txt");
        }
    }
}
