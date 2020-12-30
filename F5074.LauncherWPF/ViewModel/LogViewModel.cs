using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using F5074.LauncherWPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace F5074.LauncherWPF.ViewModel {
    [POCOViewModel]
    public partial class LogViewModel : ViewModelBase {

        public LogViewModel()
        {

        }

        #region Refresh()
        [Command]
        public void Refresh()
        {
            try
            {
                //로그 메시지 남기기
                Thread t1 = new Thread(delegate ()
                {
                    for (int i = 0; i <= 100; i++)
                        SystemLog.WriteLog(string.Format("Thread[1] = {0}", i.ToString()));

                });

                Thread t2 = new Thread(delegate ()
                {
                    for (int i = 0; i <= 100; i++)
                        SystemLog.WriteLog(string.Format("Thread[2] = {0}", i.ToString()));

                });
                t1.Start();
                t1.Join();
                //t1.Abort();
                t2.Start();
                t2.Join();
                //t2.Abort();

                this.LogDir = SystemProperties.LogDir;
            }
            catch (Exception ex)
            {
                SystemProperties.ShowError(ex.Message);
                return;
            }

        }
        #endregion

        #region Variable
        private string _LogDir;
        public string LogDir {
            get { return _LogDir; }
            set { SetProperty(ref _LogDir, value, () => LogDir); }
        }


        private bool _IsUpdate;
        public bool IsUpdate {
            get { return _IsUpdate; }
            set { SetProperty(ref _IsUpdate, value, () => IsUpdate); }
        }
        private bool _IsDelete;
        public bool IsDelete {
            get { return _IsDelete; }
            set { SetProperty(ref _IsDelete, value, () => IsDelete); }
        }
        #endregion

    }
}
