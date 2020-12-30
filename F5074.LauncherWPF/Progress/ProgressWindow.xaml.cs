using DevExpress.Xpf.Core;
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

namespace F5074.LauncherWPF.Progress {
    /// <summary>
    /// ProgressWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProgressWindow : Window, ISplashScreen {
        public ProgressWindow()
        {
            InitializeComponent();
            this.board.Completed += OnAnimationCompleted;
        }

        void ISplashScreen.CloseSplashScreen()
        {
            this.board.Begin(this);
        }

        void ISplashScreen.Progress(double value)
        {
        }

        void ISplashScreen.SetProgressState(bool isIndeterminate)
        {
        }

        void OnAnimationCompleted(object sender, EventArgs e)
        {
            this.board.Completed -= OnAnimationCompleted;
            this.Close();
        }
    }
}
