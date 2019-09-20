using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 獲得檔案路徑
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.取得和設置當前目錄（即該進程從中啟動的目錄）的完全限定路徑。
            string path1 = Environment.CurrentDirectory;
            Console.WriteLine($"↓Environment.CurrentDirectory;↓\n{path1}\n");

            //2.取得啟動了應用程序的可執行文件的路徑，不包括可執行文件的名稱。
            string path2 = System.Windows.Forms.Application.StartupPath;
            Console.WriteLine($"↓System.Windows.Forms.Application.StartupPath↓\n{path2}\n");

            //3.取得應用程序的當前工作目錄。
            string path3 = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine($"↓System.IO.Directory.GetCurrentDirectory();↓\n{path3}\n");

            //4.取得當前 Thread 的當前應用程序域的基目錄，它由程序集衝突解決程序用來探測程序集。
            string path4 = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"↓AppDomain.CurrentDomain.BaseDirectory;↓\n{path4}\n");

            //5.取得和設置包含該應用程序的目錄的名稱。
            string path5 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Console.WriteLine($"↓AppDomain.CurrentDomain.SetupInformation.ApplicationBase;↓\n{path5}\n");

            //6.取得啟動了應用程序的可執行文件的路徑，包括可執行文件的名稱。
            string path6 = System.Windows.Forms.Application.ExecutablePath;
            Console.WriteLine($"↓System.Windows.Forms.Application.ExecutablePath;↓\n{path6}\n");

            //7.取得當前執行的exe的文件名。
            string path7 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine($"↓System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;↓\n{path7}\n");

            Program p = new Program();
            p.GetPath();
            Console.ReadKey();
        }
        public void GetPath()
        {
            //8.取得當前進程的完整路徑，包含文件名。
            string path8 = this.GetType().Assembly.Location;
            Console.WriteLine($"↓this.GetType().Assembly.Location; ↓\n{path8}\n");
        }
    }
}
