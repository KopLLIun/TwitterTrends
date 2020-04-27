using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwiterTrends.Utility
{
    static class SentimentParser
    {
        public static Dictionary<string, double> ParseSentiment(string fileName)
        {
            Dictionary<string, double> sentiments = new Dictionary<string, double>();
            //For convert string with dot to double
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] sentiment = line.Split(new char[] { ',' });
                    sentiments.Add(sentiment[0], Double.Parse(sentiment[1]));
                }
            }
            //Return culture back
            Thread.CurrentThread.CurrentCulture = temp_culture;
            return sentiments;
        }
    }
}
