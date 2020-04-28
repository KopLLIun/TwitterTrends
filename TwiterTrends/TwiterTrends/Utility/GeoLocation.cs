using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        //Calculate centroid of polygon
        public static Point CalculateGeoCenter(JArray coordinates)
        {
            double ceneterLatitude = 0;
            double ceneterLongitude = 0;
            double area = 0;

            if (coordinates.Count == 1)
            {
                for (int j = 0; j < coordinates[0].Count() - 1; j++)
                {
                    double s = ((Double.Parse(coordinates[0][j][0].ToString()) * Double.Parse(coordinates[0][j + 1][1].ToString())) -
                        (Double.Parse(coordinates[0][j + 1][0].ToString()) * Double.Parse(coordinates[0][j][1].ToString())));
                    area += 0.5 * s;
                    ceneterLatitude += (1 / (6 * area)) *
                        ((Double.Parse(coordinates[0][j][0].ToString()) * Double.Parse(coordinates[0][j + 1][0].ToString())) * s);
                    ceneterLongitude += (1 / (6 * area)) *
                        ((Double.Parse(coordinates[0][j][1].ToString()) * Double.Parse(coordinates[0][j + 1][1].ToString())) * s);
                }
            }
            else
            {
                for (int i = 0; i < coordinates.Count; i++)
                {
                    for (int k = 0; k < coordinates[i][0].Count() - 1; k++)
                    {
                        double s = ((Double.Parse(coordinates[i][0][k][0].ToString()) * Double.Parse(coordinates[i][0][k + 1][1].ToString())) -
                            (Double.Parse(coordinates[i][0][k + 1][0].ToString()) * Double.Parse(coordinates[i][0][k][1].ToString())));
                        area += 0.5 * s;
                        ceneterLatitude += (1 / (6 * area)) *
                            ((Double.Parse(coordinates[i][0][k][0].ToString()) * Double.Parse(coordinates[i][0][k + 1][0].ToString())) * s);
                        ceneterLongitude += (1 / (6 * area)) *
                            ((Double.Parse(coordinates[i][0][k][1].ToString()) * Double.Parse(coordinates[i][0][k + 1][1].ToString())) * s);
                    }
                }
            }
            return new Point(ceneterLatitude, ceneterLongitude);
        }
    }
}
