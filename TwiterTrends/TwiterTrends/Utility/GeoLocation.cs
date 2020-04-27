using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwiterTrends.Utility
{
    static class GeoLocation
    {
        //Haversine formula to find distance between two points on a sphere
        public static double CalculateGeoDistance(double latitude_0, double longitude_0, double latitude_1, double longitude_1)
        {
            const double RADIUS = 6371;
            double distanceLatitude = (latitude_1 - latitude_0) * (Math.PI / 180.0);
            double distanceLongitude = (longitude_1 - longitude_0) * (Math.PI / 180.0);
            latitude_0 = (Math.PI / 180.0) * latitude_0;
            latitude_1 = (Math.PI / 180.0) * latitude_1;
            double a = Math.Pow(Math.Sin(distanceLatitude / 2), 2) + Math.Pow(Math.Sin(distanceLongitude / 2), 2)
                * Math.Cos(latitude_0) * Math.Cos(latitude_1);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return RADIUS * c;
        }
    }
}
