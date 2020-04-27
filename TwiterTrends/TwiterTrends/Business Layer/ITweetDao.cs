using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;

namespace TwiterTrends.Business_Layer
{
    interface ITweetDao
    {
        List<Tweet> GetTweets();
    }
}
