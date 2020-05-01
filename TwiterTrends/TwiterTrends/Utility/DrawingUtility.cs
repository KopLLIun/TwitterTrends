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
        public static List<Polygon> DrawMapByCoordinates(JArray coordinates)
        {
            List<Polygon> polygons = new List<Polygon>();
            if (coordinates.Count == 1)
            {
                PointCollection points = new PointCollection();
                Polygon polygon = new Polygon();
                for (int j = 0; j < coordinates[0].Count(); j++)
                {
                    //polygon.Points.Add(new Point(Double.Parse(coordinates[0][j][0].ToString()), -Double.Parse(coordinates[0][j][1].ToString())));
                    points.Add(new Point(Double.Parse(coordinates[0][j][0].ToString()) * 9 + 1400, 
                        -Double.Parse(coordinates[0][j][1].ToString()) * 9 + 700));
                }
                polygon.Points = points;
                polygons.Add(polygon);
            }
            else
            {
                for (int i = 0; i < coordinates.Count; i++)
                {
                    PointCollection points = new PointCollection();
                    Polygon polygon = new Polygon();
                    for (int k = 0; k < coordinates[i][0].Count(); k++)
                    {
                        //polygon.Points.Add(
                        //    new Point(Double.Parse(coordinates[i][0][k][0].ToString()), -Double.Parse(coordinates[i][0][k][1].ToString())));
                        points.Add(
                            new Point(Double.Parse(coordinates[i][0][k][0].ToString()) * 9 + 1400, 
                            -Double.Parse(coordinates[i][0][k][1].ToString()) * 9 + 700));
                    }
                    polygon.Points = points;
                    polygons.Add(polygon);
                }
            }
            return polygons;
        }
    }
}
