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
using System.Windows.Shapes;

namespace F5074.LauncherWPF.View.B_Chart
{
    /// <summary>
    /// Chart02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chart02 : Window
    {
        List<GDPInfo> gdps = new List<GDPInfo>();

        public Chart02()
        {
            InitializeComponent();
            gdps.Add(new GDPInfo("Russia", 1221.99, 2010, Colors.White, Color.FromRgb(0, 57, 166), Color.FromRgb(213, 43, 30)));
            gdps.Add(new GDPInfo("Germany", 3280.53, 2010, Colors.Black, Color.FromRgb(221, 0, 0), Color.FromRgb(255, 206, 0)));
            gdps.Add(new GDPInfo("Netherlands", 836.4, 2010, Color.FromRgb(174, 28, 40), Colors.White, Color.FromRgb(33, 70, 139)));
            gdps.Add(new GDPInfo("Austria", 389.7, 2010, Color.FromRgb(237, 41, 57), Colors.White, Color.FromRgb(237, 41, 57)));
            this.DataContext = gdps;
        }
        public class GDPInfo
        {
            readonly string country;
            readonly double gdp;
            readonly Color flagColor1;
            readonly Color flagColor2;
            readonly Color flagColor3;
            readonly int year;

            public string Country { get { return country; } }
            public double GDP { get { return gdp; } }
            public Brush FlagBrush1 { get { return new SolidColorBrush(flagColor1); } }
            public Brush FlagBrush2 { get { return new SolidColorBrush(flagColor2); } }
            public Brush FlagBrush3 { get { return new SolidColorBrush(flagColor3); } }
            public int Year { get { return year; } }

            public GDPInfo(string country, double gdp, int year, Color flagColor1, Color flagColor2, Color flagColor3)
            {
                this.country = country;
                this.gdp = gdp;
                this.year = year;
                this.flagColor1 = flagColor1;
                this.flagColor2 = flagColor2;
                this.flagColor3 = flagColor3;
            }
        }
    }
}
