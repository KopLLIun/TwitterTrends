using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwiterTrends.Data_Layer
{
    class Tweet
    {
        private double latitude;
        private double longitude;
        private DateTime date;
        private string comment;

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Comment { get => comment; set => comment = value; }

        public Tweet(double latitude, double longitude, DateTime date, string comment)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.date = date;
            this.comment = comment;
        }
    }
}
