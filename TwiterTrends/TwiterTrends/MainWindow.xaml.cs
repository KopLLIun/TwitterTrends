using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwiterTrends.Data_Layer;
using TwiterTrends.Service_Layer;
using TwiterTrends.Utility;

namespace TwiterTrends
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string fileName = "C:\\Ksenia\\states.json";
            //Dictionary<string, JArray> states = JsonSerializer.Deserialize<Dictionary<string, JArray>>(fileName);
            //Polygon polygon = new Polygon();
            //Point point1 = new Point(1, 2);
            //Point point2 = new Point(3, 4);
            //Point point3 = new Point(4, 1);

            //PointCollection points1 = new PointCollection();
            //PointCollection points2 = new PointCollection();
            //PointCollection points3 = new PointCollection();
            //points1.Add(point1);
            //points1.Add(point3);
            //points1.Add(point2);
            //points1.Add(point3);
            //points1.Add(point1);
            //points1.Add(point2);
            //points1.Add(point3);

            //polygon.Points = points1;
            IStateService stateService = new StateServiceImpl();
            SolidColorBrush[] brushes = new SolidColorBrush[] { Brushes.Gray, Brushes.Blue, Brushes.White, Brushes.Green, Brushes.Yellow, 
            Brushes.Orange, Brushes.AliceBlue, Brushes.Azure, Brushes.BurlyWood, Brushes.Violet};
            foreach (State state in stateService.GetStates())
            {
                Polygon polygon = DrawingUtility.DrawMapByCoordinates(state.Coordinates);
                // Stroke="Blue" StrokeThickness="1" Fill="Yellow"
                polygon.Stroke = Brushes.Black;
                polygon.Width = 900;
                polygon.Height = 900;

                Random random = new Random();
                polygon.Fill = brushes[random.Next(0, 10)];
                polygon.StrokeThickness = 1;


                aaa.Children.Add(polygon);
            }
            Console.WriteLine();
        }
    }
}
