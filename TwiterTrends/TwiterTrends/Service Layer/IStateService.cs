using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;

namespace TwiterTrends.Service_Layer
{
    interface IStateService
    {
        List<State> GetStates();

        string GetClossestStateByTweet(Tweet tweet);
    }
}
