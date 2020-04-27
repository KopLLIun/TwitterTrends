using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwiterTrends.Data_Layer
{
    class Sentiment
    {
        public string SentimentWord { get; set; }
        public double SentimentWeight { get; set; }

        public Sentiment(string sentimentWord, double sentimentWeight)
        {
            SentimentWord = sentimentWord;
            SentimentWeight = sentimentWeight;
        }
    }
}
