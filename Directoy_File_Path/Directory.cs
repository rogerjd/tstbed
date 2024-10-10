using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tstbed.Directoy_File_Path
{
    static public class Directory_tst
    {
        static public void Test()
        {
            Hello();
            ReadAllFiles();
            GetAllFilesInADirectory(); //see File.cs
        }

        private static void GetAllFilesInADirectory()
        {
            DirectoryInfo di = new DirectoryInfo(".");
            FileInfo[] fis = di.GetFiles();
            Console.WriteLine("Number of files in directory, FileInfo: " + fis.Length.ToString());

            foreach (var fi in fis)
            {
                var x = File.GetLastWriteTime(fi.DirectoryName + "\\" + fi.Name);
                Console.WriteLine(x);
                var z = fi.Extension;
                Console.WriteLine(z);
            }
        }

        private static void ReadAllFiles()
        {
            string[] files = Directory.GetFiles(".");
            Console.WriteLine("Number of files in directory: " + files.Length.ToString());

            DirectoryInfo di = new DirectoryInfo(".");
            FileInfo[] fis = di.GetFiles();
            Console.WriteLine("Number of files in directory, FileInfo: " + fis.Length.ToString());
        }

        private static void Hello()
        {
            Console.WriteLine("Hello: Directory test");
        }
    }
}


/*
bool FileExtOK(string fn)
{
    string ext = Path.GetExtension(fn);
    return (ext == ".pas") || (ext == ".dfm");
}
foreach (var fi in fis)
{
    if (!FileExtOK(fi.Name))
    {
        continue;
    }

    //FileInfo f2 = new FileInfo("a");
    var x = File.GetLastWriteTime(fi.DirectoryName + "\\" + fi.Name);
    Console.WriteLine(x);
    var z = fi.Extension;
    Console.WriteLine(z);
    // if (File.GetLastWriteTime(fi.) < CtrlDateTime)
    // {   
    //     continue;
    // }
    //res.Add(fi.Name);
}
return res;
}
*/