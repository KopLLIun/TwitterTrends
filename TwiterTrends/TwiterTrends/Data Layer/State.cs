using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TwiterTrends.Data_Layer
{
    class State
    {
        //private string name;
        //private Array coordinates;

        public string Name { get; set; }
        public JArray Coordinates { get; set; }

        public State(string name, JArray coordinates)
        {
            Name = name;
            Coordinates = coordinates;
        }
    }
}
