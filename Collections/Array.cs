
namespace tstbed.Collections
{

    static class Array
    {
        static int[] n = new int[3] { 1, 2, 3 };
        public static void Test()
        {
            Reverse();
        }

        private static void Reverse()
        {
            Console.WriteLine("Array Reverse");
            Console.WriteLine("\t {0}", string.Join(", ", n));
            System.Array.Reverse(n); // reverse the array in place (no return value)
            Console.WriteLine("\t {0}", string.Join(", ", n));
        }
    }
}