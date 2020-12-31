using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using F5074.LauncherWPF.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F5074.LauncherWPF.ViewModel {
    public partial class TextRemoveViewModel : ViewModelBase {

        [Command]
        public void Refresh1()
        {
            string str = "a/b/c";
            string[] result = str.Split(new char[] { '/' });  // /를 기준으로 잘라서 배열 result 에 넣어라.
            for (int i = 0; i < result.Length; i++)  // 배열은 0 부터 저장되며, 배열의 길이만큼 순환
            {
                Console.WriteLine(i + "/" + result[i]);
            }

            str = "f5074@naver.com";
            char[] sp = "@".ToCharArray();
            result = str.Split(sp);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i + "/" + result[i]);
            }

            str = "T E S T";
            result = str.Split(new char[] { ' ' });  // new char[] {} 로 해도 공백으로 나눈다는 의미
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i + "/" + result[i]);
            }

            str = "A~~~B~~~C~~~D";
            result = str.Split(new string[] { "~~~" }, StringSplitOptions.None);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i + "/" + result[i]);
            }

            //구글링해서 찾은걸 약간 수정해서 테스트하고 적어둠
            str = "[stop]T[stop][stop]E[stop][stop][stop]S[stop][stop]";
            string[] stringSeparators = new string[] { "[stop]" };
            result = str.Split(stringSeparators, StringSplitOptions.None);

            for (int i = 0; i < result.Length; i++)
            {
                if (String.IsNullOrEmpty(result[i]))  // 문자열이 null 이거나 공백이면
                {
                    Console.WriteLine("null" + result[i]);
                }
                else
                {
                    Console.WriteLine(i + "/" + result[i]);
                }
            }

            // 1. 샘플: 텍스트 라인별 읽기
            // StreamReader 객체를 생성한다. 입력파라미터로 File Path나 파일스트림 사용한다.
            string line;
            using (StreamReader rdr = new StreamReader(@"C:\Temp\DB.txt"))
            {
                // ReadLine()을 써서 한 라인을 읽어 들인다
                // 만약 파일 끝이면 null 이 리턴된다
                while ((line = rdr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // 2. 샘플: 텍스트 문자 몇 개만 읽기
            using (StreamReader rdr = new StreamReader(@"C:\Temp\DB.txt"))
            {
                // 한 문자 읽기
                int ch = rdr.Read();
                Console.Write(ch);

                // 현재 파일 포인터 위치에서 10개 문자를 읽기
                char[] buffer = new char[10];
                int readCount = rdr.Read(buffer, 0, 10);
                Console.WriteLine(buffer);
            }

            // ###### 텍스트 파일 읽기  ######
            // 모든 텍스트 한꺼번에 읽기
            string data = File.ReadAllText(@"C:\Temp\DB.txt");

            str = data;
            result = str.Split(new string[] { "," }, StringSplitOptions.None);
            for (int i = 0; i < result.Length; i++)
            {
                SystemProperties.ShowInformation(i + "/" + result[i]);
            }

            Console.WriteLine(data);

            //// 모든 라인들을 읽어 문자열 배열에 넣기
            //string[] allLines = File.ReadAllLines(@"C:\Temp\data.txt");

            //// 한 라인씩 읽기
            //IEnumerable<string> lines = File.ReadLines(@"C:\Temp\data.txt");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}
        }

    }
}
