using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwiterTrends.Business_Layer;
using TwiterTrends.Data_Layer;
using TwiterTrends.Utility;

namespace TwiterTrends.Service_Layer
{
    class TweetServiceImpl:ITweetService
    {
        private ITweetDao tweetDao = new TweetDaoImpl();
        private ISentimentDao sentimentDao = new SentimentDaoImpl();
        private IStateDao stateDao = new StateDaoImpl();
        public double[] AnalizeTweetSentiment()
        {
            List<Tweet> tweets = tweetDao.GetTweets();
            double[] sentimentWeight = new double[tweets.Count];
            Dictionary<string, double> sentiments = sentimentDao.GetSentiments();
            int index = 0;
            foreach (Tweet tweet in tweets)
            {
                foreach (KeyValuePair<string, double> valuePair in sentiments)
                {
                    if (tweet.Comment.Contains(valuePair.Key))
                    {
                        sentimentWeight[index] += valuePair.Value;
                    }
                }
                index++;
            }
            return sentimentWeight;
        }
        
        //param - string tweetComment
        public List<string[]> ExtractTweetWords()
        {
            List<Tweet> tweets = tweetDao.GetTweets();
            List<string[]> tweetWords = new List<string[]>(tweets.Count);
            for (int index = 0; index < tweets.Count; index++)
            {
                //My list of punctuation characters
                //string[] words = Regex.Split(tweets[index].Comment, @"[ ,\\.:;\\?!—]");
                //All punctuation characters from unicode
                string[] words = Regex.Split(tweets[index].Comment, @"\p{P}| ");
                tweetWords.Add(words);
            }
            return tweetWords;

        }

        public Dictionary<string, List<Tweet>> GroupTweetsByState()
        {
            Dictionary<string, List<Tweet>> tweetsByState = new Dictionary<string, List<Tweet>>();
            List<Tweet> tweets = tweetDao.GetTweets();
            List<State> states = stateDao.GetStates();
            foreach (Tweet tweet in tweets)
            {
                foreach (State state in states)
                {
                    if (state.Coordinates.Count == 1)
                    {
                        for (int j = 0; j < state.Coordinates[0].Count(); j++) {
                            double distance = GeoLocation.CalculateGeoDistance(tweet.Latitude, tweet.Longitude,
                                Double.Parse(state.Coordinates[0][j][1].ToString()), Double.Parse(state.Coordinates[0][j][1].ToString()));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < state.Coordinates.Count; i++)
                        {
                            for (int k = 0; k < state.Coordinates[i][0].Count(); k++)
                            {
                                double distance = GeoLocation.CalculateGeoDistance(tweet.Latitude, tweet.Longitude,
                                    Double.Parse(state.Coordinates[i][0][k][0].ToString()), Double.Parse(state.Coordinates[i][0][k][1].ToString()));
                            }
                        }
                    }
                }
            }
            return tweetsByState;
        }

        public List<Tweet> GetTweets()
        {
            return tweetDao.GetTweets();
        }
    }
}
