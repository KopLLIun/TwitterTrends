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

        Dictionary<string, double> AnalizeTweetSentiment(List<Tweet> tweets);

        Dictionary<string, List<Tweet>> GroupTweetsByState();
    }
}
