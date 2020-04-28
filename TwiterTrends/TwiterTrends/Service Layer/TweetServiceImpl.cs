using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
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

        //TODO
        public Dictionary<string, List<Tweet>> GroupTweetsByState()
        {
            Dictionary<string, List<Tweet>> tweetsByState = new Dictionary<string, List<Tweet>>();
            List<Tweet> tweets = tweetDao.GetTweets();
            List<State> states = stateDao.GetStates();
            foreach (Tweet tweet in tweets)
            {
                Dictionary<string, double> tweetCenterDistance = GetTweetCenterDistance(states, tweet);
                string key = tweetCenterDistance.OrderBy(k => k.Value).FirstOrDefault().Key;
                tweetsByState.Add(key, new List<Tweet>());
                tweetsByState[key].Add(tweet);

                //TODO some operations to calculate min distance and group tweet by state


                //List<double> tweetCenterDistance = new List<double>();
                //foreach (KeyValuePair<string, Point> stateCenter in stateCenters)
                //{
                //    tweetCenterDistance.Add(GeoLocation.CalculateGeoDistance(stateCenter.Value.X, stateCenter.Value.Y, 
                //        tweet.Latitude, tweet.Longitude));
                //    //TODO some oeperations 
                //    tweetsByState.Add(stateCenter.Key, new List<Tweet>());
                //}
            }
            return tweetsByState;
        }

        private Point GetCentersStatesPolygon(List<State> states)
        {

            return new Point();
        }

        private Dictionary<string, double> GetTweetCenterDistance(List<State> states, Tweet tweet)
        {
            Dictionary<string, double> tweetCenterDistance = new Dictionary<string, double>(states.Count);
            foreach (State state in states)
            {
                Point pointCenter = GeoLocation.CalculateGeoCenter(state.Coordinates);
                tweetCenterDistance.Add(state.Name, GeoLocation.CalculateGeoDistance(pointCenter.X, pointCenter.Y, tweet.Latitude, tweet.Longitude));
            }
            return tweetCenterDistance;
        }

        public List<Tweet> GetTweets()
        {
            return tweetDao.GetTweets();
        }
    }
}
