using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest
{
    class Program
    {
        static Process process;
        static void Main(string[] args)
        {
            Init();


            Start();

            WaitForExit();
        }

        static void Init()
        {
            process = new Process();

            process.OutputDataReceived += (sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                Console.WriteLine("실행파일 : " + e.Data);
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                Console.WriteLine(e.Data);
            };

            InitStartInfo();
        }

        static void InitStartInfo()
        {
            process.StartInfo = new ProcessStartInfo();
            // 수정
            process.StartInfo.FileName = Environment.CurrentDirectory + "/실행파일.exe";
            //process.StartInfo.Arguments = "파라미터";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
        }

        static void Start()
        {
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        static void WaitForExit()
        {
            process.WaitForExit();
        }
    }
}
