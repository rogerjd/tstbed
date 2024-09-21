using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace tstbed.Directoy_File_Path
{
    public static class csv_file
    {
        public static void Read()
        {
            using TextFieldParser parser = new TextFieldParser("csv_file1.txt");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                foreach (string fld in fields)
                {
                    Console.WriteLine(fld);
                }
            }
        }
    }
}