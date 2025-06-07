namespace tstbed.Lang
{
    static class Cond
    {
        public static void Main()
        {
            Console.WriteLine("Cpnd");

            If_ternary_test();
            pattern_matching();
        }


        static void If_ternary_test()
        {
            // conditional operator ?:, also known as the ternary conditional operator, 
            // evaluates a Boolean expression and returns the result of one of the two expressions, 
            // depending on whether the Boolean expression evaluates to true or false
            // if else
            int a = 2;
            var z = (a == 3) ? 5 : 7;
            Console.WriteLine(z);
        }

        static void pattern_matching()
        {
            object input = "Hello World";
            if (input is string text)
            {
                Console.WriteLine(text);
                
            }
            
        }
    }
}