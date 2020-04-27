using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TwiterTrends.Data_Layer;
using TwiterTrends.Service_Layer;
using TwiterTrends.Utility;

namespace TwiterTrends
{
    class Programm
    {
        public static void Main(string[] args)
        {
            //string fileName = "C:\\Ksenia\\states.json";
            //Dictionary<string, JArray> states = JsonSerializer.Deserialize<Dictionary<string, JArray>>(fileName);

            IStateService stateService = new StateServiceImpl();
            string s = stateService.GetClossestStateByTweet(new Tweet(12, 11, new DateTime(), "asd"));
            //List<State> states = stateService.GetStates();
            //int count = states[1].Coordinates[0].Count();

            //double count = Double.Parse(states[0].Coordinates[0].Count);
            //ITweetService tweetService = new TweetServiceImpl();
            //List<Tweet> tweets = tweetService.GetTweets();
            //List<string[]> tweetWords = tweetService.ExtractTweetWords();
            Console.WriteLine();
        }
    }
}
