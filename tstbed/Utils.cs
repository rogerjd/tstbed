using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    static class Utils
    {
        internal static void WriteTopic(string topic)
        {
            Console.WriteLine("\n{0} ****", topic);
        }

        internal static void WriteSubTopic(string subTtopic)
        {
            Console.WriteLine("  {0} **", subTtopic);
        }

        internal static void WriteDetailLine(string ln)
        {
            Console.WriteLine("    {0}", ln);
        }
    }
}
