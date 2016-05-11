using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dict
    {
        Dictionary<string, string> d = new Dictionary<string, string> { ["abc"] = "123" }; //ref: or {{"k", "v"}}

        public Dict()
        {
            tst();
        }

        void tst()
        {
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
        }
    }
}
