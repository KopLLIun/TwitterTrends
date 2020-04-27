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
    class SentimentServiceImpl : ISentimentService
    {
        private ISentimentDao sentimentDao = new SentimentDaoImpl();
        public Dictionary<string, double> GetSentiments()
        {
            return sentimentDao.GetSentiments();
        }
    }
}
