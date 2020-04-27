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
    class StateServiceImpl : IStateService
    {
        private IStateDao stateDao = new StateDaoImpl();
        //private ITweetDao tweetDao = new TweetDaoImpl();

        public string GetClossestStateByTweet(Tweet tweet)
        {
            Dictionary<string, double> minDistance = new Dictionary<string, double>();
            foreach (State state in stateDao.GetStates())
            {
                List<double> distances = new List<double>();
                if (state.Coordinates.Count == 1)
                {
                    for (int j = 0; j < state.Coordinates[0].Count(); j++)
                    {
                        double distance = GeoLocation.CalculateGeoDistance(tweet.Latitude, tweet.Longitude,
                            Double.Parse(state.Coordinates[0][j][1].ToString()), Double.Parse(state.Coordinates[0][j][1].ToString()));
                        distances.Add(distance);
                    }
                    minDistance.Add(state.Name, distances.Min());
                }
                else
                {
                    for (int i = 0; i < state.Coordinates.Count; i++)
                    {
                        for (int k = 0; k < state.Coordinates[i][0].Count(); k++)
                        {
                            double distance = GeoLocation.CalculateGeoDistance(tweet.Latitude, tweet.Longitude,
                                Double.Parse(state.Coordinates[i][0][k][0].ToString()), Double.Parse(state.Coordinates[i][0][k][1].ToString()));
                            distances.Add(distance);
                        }
                    }
                    minDistance.Add(state.Name, distances.Min());
                }
            }
            return minDistance.OrderBy(state => state.Value).FirstOrDefault().Key;
        }

        public List<State> GetStates()
        {
            return stateDao.GetStates();
        }
    }
}
