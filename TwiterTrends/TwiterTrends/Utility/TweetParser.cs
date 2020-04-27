using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;

namespace TwiterTrends.Utility
{
    static class TweetParser
    {
        public static List<Tweet> ParseTweets(string fileName)
        {
            List<Tweet> tweets = new List<Tweet>();
            //For convert string with dot to double
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Regex regex = new Regex("\\[(\\-?[0-9]+\\.[0-9]+)\\,.(\\-?[0-9]+\\.[0-9]+)\\].(.)*.([0-9]{4}\\-[0-9]{2}\\-[0-9]{2}.[0-9]{2}:[0-9]{2}:[0-9]{2}).(.*)");
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        double latitude = Double.Parse(match.Groups[1].Value);
                        double longitude = Double.Parse(match.Groups[2].Value);
                        DateTime date = DateTime.ParseExact(match.Groups[4].Value, "yyyy-MM-dd HH:mm:ss", null);
                        string comment = match.Groups[5].Value;
                        tweets.Add(new Tweet(latitude, longitude, date, comment));
                    }
                }
            }
            //Return culture back
            Thread.CurrentThread.CurrentCulture = temp_culture;
            return tweets;
        }
    }
}
