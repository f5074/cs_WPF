using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using F5074.LauncherWPF.Common;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F5074.LauncherWPF.ViewModel {
    public class PPTConverterViewModel : ViewModelBase {

        string Path = @"C:\DEV\aaa.ppt";

        Presentation PPT;


        [Command]
        public void OpenFileName()
        {
            FileName = SystemProperties.FileDialogShow("File (*.ppt, *.pptx) | *.ppt; *.pptx; | 모든 파일 (*.*) | *.*");

        }

        [Command]
        public void OpenFileDirectory()
        {
            SaveDirectory = SystemProperties.FolderBrowserDialogShow();
        }


        [Command]
        public void Save()
        {
            try
            {
                ApplicationClass app = new ApplicationClass();

                PPT = app.Presentations.Open(FileName, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                string myPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                for (int slideIdx = 0; slideIdx < PPT.Slides.Count; ++slideIdx)
                {
                    int idx = slideIdx + 1;
                    int width = (int)PPT.Slides[idx].Master.Width;
                    int height = (int)PPT.Slides[idx].Master.Height;
                    PPT.Slides[idx].Export(string.Format(@"{0}\\temp{1}.jpg", SaveDirectory, idx), "JPG", width, height);

                }
                SystemProperties.ShowInformation("Save Successful");
            }
            catch (Exception ex)
            {
                SystemProperties.ShowError(ex.Message);
                return;
            }
        }

        private string _FileName;
        public string FileName {
            get { return _FileName; }
            set { SetProperty(ref _FileName, value, () => FileName); }
        }

        private string _SaveDirectory;
        public string SaveDirectory {
            get { return _SaveDirectory; }
            set { SetProperty(ref _SaveDirectory, value, () => SaveDirectory); }
        }
    }
}
