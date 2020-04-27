using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;
using TwiterTrends.Utility;

namespace TwiterTrends.Business_Layer
{
    class StateDaoImpl : IStateDao
    {
        string fileName = "C:\\Ksenia\\states.json";
        public List<State> GetStates()
        {
            return StateParser.ParseStates(fileName);
        }
    }
}
