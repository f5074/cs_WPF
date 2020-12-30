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
//using Excel = Microsoft.Office.Interop.Excel;


namespace F5074.LauncherWPF.View.E_UserControl {
    /// <summary>
    /// ExcelView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ExcelView : UserControl {
        public ExcelView()
        {
            InitializeComponent();
        }

        
        private void Init()
        {
            // https://m.blog.naver.com/PostView.nhn?blogId=cheongsik&logNo=30039217861&proxyReferer=https:%2F%2Fwww.google.com%2F
            //Excel.Workbook workbook = null;
            //Excel.Worksheet worksheet = null;
            //Excel.Application application = null;
            //public ExcelView()
            //{
            //    InitializeComponent();


            //    object missing = System.Reflection.Missing.Value;
            //    object fileName = System.IO.Directory.GetCurrentDirectory() + @"\Test.xls";
            //    try
            //    {
            //        application = new Excel.Application();
            //        //application.WindowDeactivate += new Excel.AppEvents_WindowDeactivateEventHandler(Application_ExcelDeactivate);
            //        application.Visible = true; // 엑셀창이 나타나지 않고 작업을 진행하기 위해서...
            //        workbook = application.Workbooks.Add(missing);
            //        worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];
            //        worksheet.Name = "It's Me";
            //        worksheet.Cells[1, 1] = "Details ^^";
            //        worksheet.Cells[2, 1] = "Name : ";
            //        worksheet.Cells[3, 1] = "Age : ";
            //        worksheet.Cells[4, 1] = "Designation : ";
            //        worksheet.Cells[5, 1] = "Company : ";
            //        worksheet.Cells[6, 1] = "Place : ";
            //        worksheet.Cells[7, 1] = "Email : ";
            //        worksheet.get_Range("A1", "A1").Font.Bold = true;
            //        worksheet.get_Range("A1", "A6").EntireColumn.AutoFit();
            //        worksheet.get_Range("A1", "A7").BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium,
            //                        Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        if (System.IO.File.Exists((string)fileName)) // 동일한 파일이 있으면 삭제하자.
            //        {
            //            System.IO.File.Delete((string)fileName);
            //        }
            //        // 동일한 파일이 있는 경우 SaveAs를 하면 팝업창이 떠서 묻기 때문에 이를 없애기 위해...
            //        // SavaAs 메소드에서 이 옵션을 못찾겠어요 ㅜ.ㅜ
            //        workbook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlShared, Excel.XlSaveConflictResolution.xlLocalSessionChanges, missing, missing, missing, missing);

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message + " !");
            //    }
            //    finally
            //    {
            //        workbook.Close(true, fileName, Type.Missing);
            //        workbook = null;
            //        if (application != null) // 작업후 프로세스가 남는 경우를 방지하기 위해서...
            //        {
            //            Process[] pProcess;
            //            pProcess = System.Diagnostics.Process.GetProcessesByName("Excel");
            //            pProcess[0].Kill();
            //        }
            //        application = null;
            //    }

            //}
            //public void Save()
            //{
            //    try
            //    {
            //        object missing = System.Reflection.Missing.Value;
            //        application = new Excel.Application();
            //        //application.WindowDeactivate += new Excel.AppEvents_WindowDeactivateEventHandler(Application_ExcelDeactivate);
            //        string excelFile = System.IO.Directory.GetCurrentDirectory() + @"\Test.xls";
            //        workbook = application.Workbooks.Open(excelFile, missing, missing,
            //                                              missing, missing, missing, missing, missing, missing,
            //                                              missing, missing, missing, missing, missing, missing);
            //        worksheet = (Excel.Worksheet)workbook.Sheets["It's Me"];
            //        worksheet.Cells[1, 1] = "Details ----";
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message + " !");

            //    }
            //    finally
            //    {
            //        workbook.Close(true, Type.Missing, Type.Missing);
            //        workbook = null;
            //        if (application != null)
            //        {
            //            Process[] pProcess;
            //            pProcess = System.Diagnostics.Process.GetProcessesByName("Excel");
            //            pProcess[0].Kill();
            //        }
            //        application = null;
            //    }


            //}
        }
    }
}
