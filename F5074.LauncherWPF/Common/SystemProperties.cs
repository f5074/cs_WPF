using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using F5074.LauncherWPF.Progress;
using F5074.WPF.Common.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace F5074.LauncherWPF.Common {
    public class SystemProperties {

        public static string PROGRAM_TITLE {
            get { return "F5074 WPF"; }
        }

        public static string LogDir {
            get;
            set;
        }

        public static string PROGRAM_NAME {
            get { return "/F5074.LauncherWPF;component/"; }
        }

        /// <summary>
        /// ScreenShow DXSplashScreen
        /// </summary>
        public static void ScreenShow() {
            DXSplashScreen.Show<ProgressWindow>();
        }

        /// <summary>
        /// ScreenClose DXSplashScreen
        /// </summary>
        public static void ScreenClose()
        {
            DXSplashScreen.Close();
        }

        /// <summary>
        /// ShowError WinUIMessageBox
        /// </summary>
        /// <param name="message"></param>
        public static void ShowError(string message)
        {
            if (DXSplashScreen.IsActive) DXSplashScreen.Close();
            WinUIMessageBox.Show(message, MesssageTitle(ProgramMessageType.Error), MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// ShowInformation WinUIMessageBox
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInformation(string message)
        {
            if (DXSplashScreen.IsActive) DXSplashScreen.Close();
            WinUIMessageBox.Show(message, MesssageTitle(ProgramMessageType.Information), MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// ShowWarning WinUIMessageBox
        /// </summary>
        /// <param name="message"></param>
        public static void ShowWarning(string message)
        {
            if (DXSplashScreen.IsActive) DXSplashScreen.Close();
            WinUIMessageBox.Show(message, MesssageTitle(ProgramMessageType.Warning), MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// MesssageTitle
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static string MesssageTitle(ProgramMessageType messageType)
        {
            return String.Format("[{0}] {1}", SystemProperties.PROGRAM_TITLE, messageType.ToString());
        }
    }
}
