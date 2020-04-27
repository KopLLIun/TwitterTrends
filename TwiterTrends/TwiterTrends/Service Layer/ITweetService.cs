using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;

namespace TwiterTrends.Service_Layer
{

    interface ITweetService
    {
        List<Tweet> GetTweets();

        double[] AnalizeTweetSentiment();

        //param - string tweetComment
        List<string[]> ExtractTweetWords();

        Dictionary<string, List<Tweet>> GroupTweetsByState();
    }
}
