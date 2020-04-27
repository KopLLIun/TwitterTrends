using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwiterTrends.Business_Layer
{
    interface ISentimentDao
    {
        Dictionary<string, double> GetSentiments();
    }
}
