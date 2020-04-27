using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiterTrends.Data_Layer;

namespace TwiterTrends.Utility
{
    class StateParser
    {
        public static List<State> ParseStates(string fileName)
        {
            List<State> states = new List<State>();
            Dictionary<string, JArray> map = JsonSerializer.Deserialize<Dictionary<string, JArray>>(fileName);
            foreach (KeyValuePair<string, JArray> state in map)
            {
                states.Add(new State(state.Key, state.Value));
                //double state = Double.Parse((map["WA"] as JArray)[0][0][0][0].ToString());
            }
            return states;
        }
    }
}
