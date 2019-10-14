using DevExpress.Xpf.Core.ServerMode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace F5074.LauncherWPF.View.C_GridControl
{
    /// <summary>
    /// Grid01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Grid01 : Window
    {
        public Grid01()
        {
            InitializeComponent();
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            for (int i = 0; i < 1000; i++)
            {
                customers.Add(new Customer() { ID = 1, Contacts = new ObservableCollection<string>() { "name1", "name2" } });
                customers.Add(new Customer() { ID = 2, Contacts = new ObservableCollection<string>() { "name1", "name2", "name3" } });
                customers.Add(new Customer() { ID = 3, Contacts = new ObservableCollection<string>() { "name1", "name2", "name3" } });
                customers.Add(new Customer() { ID = 4, Contacts = new ObservableCollection<string>() { "name1", "name2", "name3" } });
                customers.Add(new Customer() { ID = 5, Contacts = new ObservableCollection<string>() { "name1", "name2", "name3", "name4" } });
            }

            PLinqInstantFeedbackDataSource source = new PLinqInstantFeedbackDataSource();
            source.ItemsSource = customers;

            grid.ItemsSource = source.Data;
        }
        public class Customer
        {
            public int ID
            {
                get;
                set;
            }

            public ObservableCollection<string> Contacts
            {
                get;
                set;
            }
        }
    }
}
