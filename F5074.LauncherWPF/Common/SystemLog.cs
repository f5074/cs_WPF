using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F5074.LauncherWPF.Common {
    public class SystemLog {
        private static string strLogDir = System.IO.Directory.GetCurrentDirectory() + @"\Log\";
        private static string strLogFile = "Log";
        private static readonly object thisLock = new object();

        public SystemLog()
        {
        }

        public static void SetLogPath(string strDir)
        {
            strLogDir = strDir;
        }

        public static void SetLogFile(string strFile)
        {
            strLogFile = strFile;
        }

        public static void WriteLog(string strLog)
        {
            WriteLog(strLog, LogCode.Infomation, strLogFile);
        }

        public static void WriteLog(string strLog, string strFileName)
        {

            WriteLog(strLog, LogCode.Infomation, strFileName, strLogDir);
        }

        public static void WriteLog(string strLog, string strFileName, string strPath)
        {
            WriteLog(strLog, LogCode.Infomation, strFileName, strPath);
        }

        public static void WriteLog(string strLog, LogCode logCode)
        {
            WriteLog(strLog, logCode, strLogFile);
        }

        public static void WriteLog(string strLog, LogCode logCode, string strFileName)
        {

            WriteLog(strLog, logCode, strFileName, strLogDir);
        }

        public static void WriteLog(string strLog, LogCode logCode, string strFileName, string strPath)
        {
            string strFullName;

            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }

            if (strPath.EndsWith(@"\") == false || strPath.EndsWith("/") == false)
            {
                strPath = strPath + @"\";
            }
            strFullName = strPath + strFileName + "_" + DateTime.Now.ToShortDateString() + ".txt";

            //로그 디렉토리 위치 불러오기위해 저장
            SystemProperties.LogDir = strLogDir;

            string strFullLog = DateTime.Now.ToString("HH:mm:ss") + " (" + logCode.ToString() + ")" + " : " + strLog;

            lock (thisLock)
            {
                StreamWriter sw = new StreamWriter(strFullName, true, System.Text.Encoding.UTF8, 4096);
                sw.WriteLine(strFullLog);
                sw.Close();
            }
        }

        public enum LogCode {
            Infomation = 0,
            Success = 1,
            Error = -1,
            Failure = -2,
            Warning = -10,
            SystemError = -101,
            ApplicationError = -201
        }
    }
}
