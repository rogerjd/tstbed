using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Directoy_File_Path
{
    static class PathTst
    {
        static string FileName = "abc.txt";

        public static void Test()
        {
            Utils.WriteTopic("Path, IO");
            Extention();
        }

        private static void Extention()
        {
            Utils.WriteSubTopic("Extension");
            Utils.WriteDetailLine($"File: {FileName} Ext: {Path.GetExtension(FileName)}");
        }
    }
}
