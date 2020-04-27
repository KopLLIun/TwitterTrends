using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Utility;

namespace TwiterTrends.Business_Layer
{
    class SentimentDaoImpl : ISentimentDao
    {
        string fileName = "C:\\Ksenia\\sentiments.csv";
        public Dictionary<string, double> GetSentiments()
        {
            return SentimentParser.ParseSentiment(fileName);
        }
    }
}
