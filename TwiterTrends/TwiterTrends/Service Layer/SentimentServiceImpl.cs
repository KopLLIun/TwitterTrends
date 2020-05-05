using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Business_Layer;
using TwiterTrends.Data_Layer;
using TwiterTrends.Utility;

namespace TwiterTrends.Service_Layer
{
    class SentimentServiceImpl : ISentimentService
    {
        private ISentimentDao sentimentDao = new SentimentDaoImpl();
        private ITweetService tweetService = new TweetServiceImpl();

        public Dictionary<string, double> CalculateAverageSentiments(Dictionary<string, List<Tweet>> tweetsByState)
        {
            Dictionary<string, double> averageSetntiments = new Dictionary<string, double>();
            foreach (KeyValuePair<string, List<Tweet>> tweetsState in tweetsByState)
            {
                double averageSentimentWeight = 0;
                Dictionary<string, double> tweetSentiment = tweetService.AnalizeTweetSentiment(tweetsState.Value);
                foreach (KeyValuePair<string, double> valuePair in tweetSentiment)
                {
                    averageSentimentWeight += valuePair.Value / tweetSentiment.Count;
                }
                averageSetntiments.Add(tweetsState.Key, averageSentimentWeight);
            }
            return averageSetntiments;
        }

        public Dictionary<string, double> GetSentiments()
        {
            return sentimentDao.GetSentiments();
        }
    }
}
