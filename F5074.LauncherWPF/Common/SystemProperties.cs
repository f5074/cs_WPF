using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using F5074.LauncherWPF.Progress;
using F5074.WPF.Common.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

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

        public static void AdminRelauncher()
        {
            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;

                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                    System.Windows.Application.Current.Shutdown();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("This program must be run as an administrator! \n\n" + ex.ToString());
                }
            }
        }
        private static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// FileDialogShow
        /// </summary>
        /// <returns></returns>
        public static string FileDialogShow(string filter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open File Diallog";
            ofd.FileName = "";
            ofd.Filter = filter;

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string fileName = ofd.SafeFileName;
                string fileFullName = ofd.FileName;
                string filePath = fileFullName.Replace(fileName, "");

                return fileFullName;
            }
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }

            return "";
        }

        public static string FolderBrowserDialogShow()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            return folderBrowserDialog.SelectedPath;
        }
    }
}
