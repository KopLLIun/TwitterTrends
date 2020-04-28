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
        private string fileName = "C:\\Ksenia\\tweets.txt";
        public List<Tweet> GetTweets()
        {
            return TweetParser.ParseTweets(fileName);
        }
    }
}
