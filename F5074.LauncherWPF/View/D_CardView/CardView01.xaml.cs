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

namespace F5074.LauncherWPF.View.D_CardView {
    /// <summary>
    /// CardView01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardView01 : Window {
        public CardView01()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Init
        /// </summary>
        private void Init()
        {
            for (int x = 0; x < 5; x++)
            {
                DevExpress.Xpf.LayoutControl.GroupBox groupBox = new DevExpress.Xpf.LayoutControl.GroupBox() { Header = "xx" + x, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, MaximizeElementVisibility = Visibility.Visible };
                System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
                //host.Child = new F5074.DevExpressWinforms.Dashboard.FlowPanelControl();
                groupBox.Content = host;
                this.flowLayout.Children.Add(groupBox);

            }
        }
    }
}
