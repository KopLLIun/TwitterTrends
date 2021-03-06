﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;

namespace TwiterTrends.Service_Layer
{
    interface ISentimentService
    {
        Dictionary<string, double> GetSentiments();

        Dictionary<string, double> CalculateAverageSentiments(Dictionary<string, List<Tweet>> tweetsByState);
    }
}
