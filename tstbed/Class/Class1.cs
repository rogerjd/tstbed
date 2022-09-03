using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Class
{
    static class Class1
    {

        class MyClass
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public static void Test()
        {
            Utils.WriteTopic("Class Test");
        }

        static void ObjectInitializer()
        {
            MyClass mc = new MyClass{ Name = "j", ID = 2}; // or with () ctor
        }
    }
}
