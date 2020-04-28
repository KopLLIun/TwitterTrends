using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TwiterTrends.Utility
{
    static class DrawingUtility
    {
        public static Polygon DrawMapByCoordinates(JArray coordinates)
        {
            Polygon polygon = new Polygon();
            PointCollection points = new PointCollection();
            if (coordinates.Count == 1)
            {
                for (int j = 0; j < coordinates[0].Count(); j++)
                {
                    //polygon.Points.Add(new Point(Double.Parse(coordinates[0][j][0].ToString()), -Double.Parse(coordinates[0][j][1].ToString())));
                    points.Add(new Point(Double.Parse(coordinates[0][j][0].ToString()), -Double.Parse(coordinates[0][j][1].ToString())));
                }
                polygon.Points = points;
            }
            else
            {
                for (int i = 0; i < coordinates.Count; i++)
                {
                    for (int k = 0; k < coordinates[i][0].Count(); k++)
                    {
                        //polygon.Points.Add(
                        //    new Point(Double.Parse(coordinates[i][0][k][0].ToString()), -Double.Parse(coordinates[i][0][k][1].ToString())));
                        points.Add(
                            new Point(Double.Parse(coordinates[i][0][k][0].ToString()), -Double.Parse(coordinates[i][0][k][1].ToString())));
                    }
                }
                polygon.Points = points;
            }
            return polygon;
        }
    }
}
