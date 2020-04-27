using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwiterTrends.Service_Layer
{
    interface ISentimentService
    {
        Dictionary<string, double> GetSentiments();
    }
}
