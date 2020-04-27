using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwiterTrends.Utility
{
    internal static class JsonSerializer
    {
        internal static void Serialize<T>(this T arg, string fileName)
        {
            string result = JsonConvert.SerializeObject(arg, Formatting.Indented);
            File.WriteAllText(fileName, result);
        }

        internal static T Deserialize<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
